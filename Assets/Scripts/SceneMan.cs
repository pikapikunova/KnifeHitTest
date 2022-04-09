using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMan : MonoBehaviour
{
    public GameObject start;
    public GameObject restart;

    public static int lev;
    public static int score;
    public static int maxScore;
    public static int heartScore;

    public static SaveLoad sl;
    public static dataSaved dataS;
    public static bool flag1 = true;

    public void startGame() 
    {
        initialCond();
        SceneManager.LoadScene(1);
    }

    public void goHome()
    {
        if (score > maxScore)
            maxScore = score;
        restart.SetActive(false);
        start.SetActive(true);
    }

    public void exit()
    {
        dataS.heartSc = heartScore;
        dataS.maxSc = maxScore;
        sl.SaveGame(dataS);
      
        Application.Quit();
    }

    public void initialCond()
    {
        if (score > maxScore)
            maxScore = score;

        lev = 0;
        numOfKnife.numOfKn = 5;
        score = 0;
    }

    public void Start()
    {
        if (flag1)
        {
            lev = Resources.Load<gameInfo>("gameInf").level;
            score = Resources.Load<gameInfo>("gameInf").score;
            maxScore = Resources.Load<gameInfo>("gameInf").maxScore;
            heartScore = Resources.Load<gameInfo>("gameInf").heartScore;

    sl = new SaveLoad();
            dataS = (dataSaved)sl.LoadGame(new dataSaved());
            
            maxScore = dataS.maxSc;
            heartScore = dataS.heartSc;

            flag1 = false;
        }
        else
        {
            restart.SetActive(true);
            start.SetActive(false);
        }

    }

}
