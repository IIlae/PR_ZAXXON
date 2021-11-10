using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFunctions : MonoBehaviour
{
    GameObject baseNave;
    MoveShip moveShip;
    Text overMessage;
    Image heartsImg;
    [SerializeField] Sprite[] heartsSprt;
    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.score = 0;
        print(GameManager.lives);
        overMessage = GameObject.Find("ded").GetComponent<Text>();
        heartsImg = GameObject.Find("hearts").GetComponent<Image>();
        baseNave = GameObject.Find("baseNave");
        moveShip = baseNave.GetComponent<MoveShip>();
        heartsImg.sprite = heartsSprt[GameManager.lives];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        dead = true;
        //Comprovación del score
        if(GameManager.score > GameManager.highScore)
        {
            GameManager.highScore = GameManager.score;
            GameManager.newBest = true;
        }

        Destroy(baseNave);
        //Comprovación de vidas, si quedan recarga la escena, si no hay saca mensaje de game over
        if(GameManager.lives < 1)
        {
            print("Game Over");
            overMessage.enabled = true;
        }
        else
        {
            print("Continue");
            GameManager.lives--;
            SceneManager.LoadScene("Screen1");
        }
        StartCoroutine("ScoreGiver");
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
