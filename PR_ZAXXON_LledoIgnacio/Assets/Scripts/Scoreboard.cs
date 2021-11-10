using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    //declaraci�n de las variables de texto
    Text highScoreTxt;
    Text scoreTxt;
    Text newHighTxt;
    // Start is called before the first frame update
    void Start()
    {
        //Asignaci�n de las variables de texto
        highScoreTxt = GameObject.Find("HighScore").GetComponent<Text>();
        newHighTxt = GameObject.Find("NewHigh").GetComponent<Text>();
        scoreTxt = GameObject.Find("CurrentScore").GetComponent<Text>();
        //Asignaci�n de valores
        highScoreTxt.text = "HIGH SCORE: " + GameManager.highScore;
        scoreTxt.text = "SCORE: " + GameManager.score;
        //condici�n para el mesaje de New High Score
        if (GameManager.newBest)
        {
            newHighTxt.enabled = true;
        }
        else
        {
            newHighTxt.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
