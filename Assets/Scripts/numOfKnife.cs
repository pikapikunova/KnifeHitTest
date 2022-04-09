using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numOfKnife : MonoBehaviour
{
    public static int numOfKn = 5;
    public GameObject actKnife;
    static GameObject[] imgs = new GameObject[numOfKn];
    public GameObject panel;
    float xPos = 100;
    float yPos = 150;
    float yKoef = 120;
    
    private void Start()
    {
        for (int i = 0; i < numOfKn; i++)
        {
            GameObject c = Instantiate(actKnife, panel.transform, false);
            c.transform.position = new Vector2(xPos, yPos + i * yKoef);
            imgs[i] = c;
        }
    }

    public static void changeColor()
    {
        for (int i = 0; i < imgs.Length; i++)
        {
            if (imgs[i].tag == "knobj" && imgs[i].GetComponent<Image>().color != new Color(0, 0, 0))
            {
                imgs[i].GetComponent<Image>().color = new Color(0, 0, 0);
                break;
            }
        }
    }
}
