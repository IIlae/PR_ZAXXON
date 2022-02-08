using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFunctions : MonoBehaviour
{
    GameObject baseNave;
    GameObject dedScreen;
    MoveShip moveShip;
    Text overMessage;
    Image heartsImg;
    //GameManager gameManager;
    [SerializeField] Sprite[] heartsSprt;
    public bool dead = false;
    private void Awake()
    {

        //gameManager = GameObject.Find("GameFunctions").GetComponent<GameManager>();
        //print(GameManager.lives);
        heartsImg = GameObject.Find("hearts").GetComponent<Image>();
        baseNave = GameObject.Find("baseNave");
        dedScreen = GameObject.Find("DedScreen");
        moveShip = baseNave.GetComponent<MoveShip>();
        heartsImg.sprite = heartsSprt[GameManager.lives];
    }
    void Start()
    {
        GameManager.score = 0;
        dedScreen.SetActive(false);
        StartCoroutine("ScoreGiver");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hitFunction()
    {
        //Comprovación de vidas, si quedan recarga la escena, si no hay saca mensaje de game over
        if(GameManager.lives < 1)
        {
            gameOver();
        }
        else
        {
            damage();
        }
    }
    private void damage()
    {
        GameManager.lives--;
        print("Hit");
    }

    private void gameOver()
    {
        Destroy(baseNave);
        dead = true;
        //Comprovación del score
        if (GameManager.score > GameManager.highScore)
        {
            GameManager.highScore = GameManager.score;
            GameManager.newBest = true;
        }

        dedScreen.SetActive(true);
        print("game over");
        //SceneManager.LoadScene("Screen1");
    }

    IEnumerator ScoreGiver()
    {
        while (!dead)
        {
            GameManager.score += moveShip.speed / 10;
            yield return new WaitForSeconds(1);
        }
    }
}
