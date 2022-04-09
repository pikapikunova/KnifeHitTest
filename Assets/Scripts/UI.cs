using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text textCurScore;
    public Text textHeartScore;
    public Text textMaxScore;
    public Toggle tog;

    private void Start()
    {
        if (tog != null)
            funMode();
    }
    void Update()
    {
        if (textCurScore != null && textCurScore.text != SceneMan.score.ToString())
            textCurScore.text = SceneMan.score.ToString();

        if (textHeartScore != null && textHeartScore.text != SceneMan.heartScore.ToString())
            textHeartScore.text = SceneMan.heartScore.ToString();

        if (textMaxScore != null && textMaxScore.text != SceneMan.maxScore.ToString())
            textMaxScore.text = "SCORE " + SceneMan.maxScore.ToString();
        
    }

    public void funMode()
    {
        if (tog.isOn)
            PlayerControl.togIsOn = true;
        else
            PlayerControl.togIsOn = false;
    }
    
}
