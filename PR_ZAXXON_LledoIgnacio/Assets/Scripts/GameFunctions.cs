using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFunctions : MonoBehaviour
{
    GameObject baseNave;
    Text overMessage;
    public bool dead = false;
    static int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        print(lives);
        overMessage = GameObject.Find("ded").GetComponent<Text>();
        baseNave = GameObject.Find("baseNave");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        dead = true;
        Destroy(baseNave);
        if(lives < 1)
        {
            overMessage.enabled = true;
        }
        else
        {
            lives--;
            SceneManager.LoadScene("Screen1");
        }
    }
}
