using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    public GameObject knifePrefab;

    void Start()
    {
        Vibration.Init();
    }

    public void throwKnife(int Speed)
    {
        Vector3 movement = new Vector3(0.0f, 1, 0.0f);
        GetComponent<Rigidbody2D>().AddForce(movement * Speed);
        SceneMan.score++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("circle"))
        {
            gameObject.AddComponent<FixedJoint2D>();
            GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            Vibration.Vibrate(60);
        }

        if (collision.gameObject.CompareTag("knobj"))
        {
            Vibration.Vibrate(60);
            SceneManager.LoadScene(0);
        }
    }
}
