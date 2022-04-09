using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameObject knifePrefab;
    public GameObject heartPrefab;

    public int Speed;
    public float timeCor;
    bool flag = false;

    public GameObject[] parts;
    public GameObject circ;
    Knife knife;

    System.Random randX = new System.Random();
    System.Random randY = new System.Random();
    System.Random rand = new System.Random();

    public static bool togIsOn = false;

    void Start()
    {
        SceneMan.lev++;

        if (togIsOn)
            changeCircSprite("circleTim");
        else
            changeCircSprite("circleSimple");

        knife = Instantiate(knifePrefab, new Vector3(0, (float)-2.7, 0), Quaternion.Euler(new Vector3(0, 0, -90))).GetComponent<Knife>();
        float r = circ.GetComponent<CircleCollider2D>().radius;

        heartGeneration(r + 0.1f, circ.transform.position.x, circ.transform.position.y);
        knifeGeneration(r, circ.transform.position.x, circ.transform.position.y);
    }

    void Update()
    {

        if (Input.anyKeyDown && numOfKnife.numOfKn != 0 && !flag)
        {
            knife.throwKnife(Speed);
            numOfKnife.numOfKn--;
            numOfKnife.changeColor();

            StartCoroutine(knifeCoroutine());
        }

        if (numOfKnife.numOfKn == 0 && !flag)
        {
            StartCoroutine(waitingEndCoroutine());
        }
    }

    IEnumerator knifeCoroutine()
    {
        flag = true;
        yield return new WaitForSeconds(timeCor);
        knife = Instantiate(knifePrefab, new Vector3(0, -2.7f, 0), Quaternion.Euler(new Vector3(0, 0, -90))).GetComponent<Knife>();
        flag = false;
    }

    IEnumerator newCoroutine()
    {
        flag = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
        numOfKnife.numOfKn = 5;
        Vibration.Vibrate(60);
        flag = false;
    }

    IEnumerator waitingEndCoroutine()
    {
        flag = true;
        yield return new WaitForSeconds(0.2f);
        circ.SetActive(false);

        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].SetActive(true);
        }

        Rigidbody2D[] physicObject = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];

        for (int i = 0; i < physicObject.Length; i++)
            physicObject[i].AddForce(new Vector2(randX.Next(-100, 200), randY.Next(-10, 200)));

        Knife[] knifes = FindObjectsOfType<Knife>();

        for (int i = 0; i < knifes.Length; i++)
        {
            knifes[i].GetComponent<Rigidbody2D>().gravityScale = 2;
            knifes[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        heart[] hearts = FindObjectsOfType<heart>();

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].GetComponent<Rigidbody2D>().gravityScale = 2;
            hearts[i].GetComponent<EdgeCollider2D>().enabled = false;
        }
        flag = false;
        StartCoroutine(newCoroutine());
    }

    public void knifeGeneration(float r, float xCirc, float yCirc)
    {
        int n = rand.Next(0, 4);

        for (int i = 0; i < n; i++)
        {
            int t;
            float x;
            float y;
            findTrueCoord(r, xCirc, yCirc, out x, out y, out t);

            if (t < 10)
            {
                float gipot = r;
                float cosAngle = x / gipot;
                float alfa = Mathf.Acos(cosAngle) * 57.3f;

                Knife kn = Instantiate(knifePrefab, new Vector3(x, y, 0), Quaternion.identity).GetComponent<Knife>();
                kn.transform.Rotate(new Vector3(0, 0, alfa));
            }
        }
    }

    public void heartGeneration(float r, float xCirc, float yCirc)
    {
        int chan = rand.Next(0, 101);
        int t;
        if (chan <= Resources.Load<chanceInfo>("chanceInf").chan)
        {
            float x;
            float y;
            findTrueCoord(r, xCirc, yCirc, out x, out y, out t);
            if (t < 10)
            {
                GameObject heart = Instantiate(heartPrefab, new Vector3(x + 0.05f, y + 0.05f, 0), Quaternion.identity);
                heart.AddComponent<FixedJoint2D>();
                heart.GetComponent<FixedJoint2D>().connectedBody = circ.GetComponent<Rigidbody2D>();
            }
        }

    }

    public void xyCoord(float r, float xCirc, float yCirc, out float x, out float y)
    {
        x = Random.Range(xCirc - r, xCirc + r);
        y = Mathf.Sqrt(r * r - Mathf.Pow(x - xCirc, 2)) + yCirc;//из уравн окружности
    }

    public void findTrueCoord(float r, float xCirc, float yCirc, out float x, out float y, out int t)
    {
        xyCoord(r, xCirc, yCirc, out x, out y);
        Rigidbody2D[] objects = FindObjectsOfType<Rigidbody2D>();
        t = 0;

        for (int i = 0; i < objects.Length; i++)
        {
            Vector2 b = new Vector2(x, y);
            Vector2 a = objects[i].transform.position;
            Vector2 center = b - a;
            t = 0;
            while (Physics2D.OverlapBox(center, new Vector2(4f, 4f), 0f) == true && Physics2D.OverlapBox(center, new Vector2(4f, 4f), 0f).gameObject.tag != "circle")
            {
                xyCoord(r, xCirc, yCirc, out x, out y);
                b = new Vector2(x, y);
                center = b - a;
                t++;
                if (t > 10)
                    break;
            }
        }
    }

    public void changeCircSprite(string name)
    {
        circ.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<circleComplectation>(name).sprite;
        for (int i = 0; i < parts.Length; i++)
            parts[i].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<circleComplectation>(name).parts[i];
    }
}

