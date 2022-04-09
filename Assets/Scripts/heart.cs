using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public GameObject[] parts;
    System.Random randX = new System.Random();
    System.Random randY = new System.Random();
    bool t = false;

    void Update()
    {
        if (t)
        {
            gameObject.SetActive(false);

            for (int i = 0; i < parts.Length; i++)
            {
                GameObject c = Instantiate(parts[i]);
                c.transform.position = gameObject.transform.position;
                if (i == 0)
                    c.transform.position -= new Vector3 (0.5f, 0, 0);
                else
                    c.transform.position += new Vector3(0.5f, 0, 0);

                c.GetComponent<Rigidbody2D>().AddForce(new Vector2(randX.Next(-100, 200), randY.Next(-10, 200)));

            }
            t = false;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("knobj"))
        {
            t = true;
            SceneMan.heartScore++;
        }
    }

}
