using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        GameManager.lives = 2;
        SceneManager.LoadScene("Screen1");
    }
    public void goToScores()
    {
        SceneManager.LoadScene("HighScore");
    }
    public void goToConfig()
    {
        SceneManager.LoadScene("ConfigMenu");
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
