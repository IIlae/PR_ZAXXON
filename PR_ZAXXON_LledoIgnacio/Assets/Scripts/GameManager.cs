using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int lives = 2;
    public static int scoreA;
    public static int highScore;
    public static int volume;
    public static bool newBest;
    public static int[] Scores = new int[10];

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static void scoreRecord()
    {
        for(int x=0; x < Scores.Length; x++)
        {
            if(Scores[x] < 1 || x > Scores.Length-1) Scores[x] = scoreA;
        }
        if (scoreA > highScore)
        {
            highScore = scoreA;
            newBest = true;
        }
        else newBest = false;
    }
}
