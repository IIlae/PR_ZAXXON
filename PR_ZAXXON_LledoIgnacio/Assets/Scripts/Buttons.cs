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

    public void startScreen1()
    {
        GameManager.lives = 2;
        SceneManager.LoadScene("Screen1");
    }
    public void startScreen3()
    {
        GameManager.lives = 2;
        SceneManager.LoadScene("Screen3");
    }
    public void goToScores()
    {
        SceneManager.LoadScene("Scores");
    }
    public void goToConfig()
    {
        SceneManager.LoadScene("ConfigMenu");
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
