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
    [SerializeField] Text[] scoreTxts;
    void Awake()
    {
        for(int x=0; x < 10; x++)
        {
            scoreTxts[x] = GameObject.Find("Score"+x).GetComponent<Text>();
        }
        //Asignaci�n de las variables de texto
        highScoreTxt = GameObject.Find("HighScore").GetComponent<Text>();
        newHighTxt = GameObject.Find("NewHigh").GetComponent<Text>();
        scoreTxt = GameObject.Find("CurrentScore").GetComponent<Text>();
    }
    void Start()
    {
        GameManager.scoreRecord();
        orderScores();
        //Asignaci�n de valores
        highScoreTxt.text = "HIGH SCORE: " + GameManager.highScore;
        //scoreTxt.text = "SCORE: " + GameManager.scoreA;
        //condici�n para el mesaje de New High Score
    }
    void orderScores()
    {
        for (int y=10; y>0; y--)
        {
            print(y);
            print(GameManager.Scores[y-1]);
            if(GameManager.Scores[y-1] > 0)
            {
                scoreTxts[10-y].text = ""+ GameManager.Scores[y-1];
                scoreTxts[10-y].enabled = true;
            }
            else scoreTxts[10-y].enabled = false;
        }
        if (GameManager.newBest)
        {
            newHighTxt.enabled = true;
        }
        else
        {
            newHighTxt.enabled = false;
        }
    }


    void Update()
    {
        
    }
}
