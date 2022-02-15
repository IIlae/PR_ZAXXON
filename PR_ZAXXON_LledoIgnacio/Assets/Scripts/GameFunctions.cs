using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFunctions : MonoBehaviour
{
    GameObject baseNave;
    GameObject dedScreen;
    GameObject explotion;
    //AudioSource bgm;
    //AudioSource overMusic;
    MoveShip moveShip;
    Text overMessage;
    Text SpeedCounter;
    Image heartsImg;
    //GameManager gameManager;
    [SerializeField] Sprite[] heartsSprt;
    private bool paused;
    public bool dead = false;
    public float speed = 50;
    public float accelNum = 0.3f;
    public float accelTime = 0.1f;
    private void Awake()
    {

        //gameManager = GameObject.Find("GameFunctions").GetComponent<GameManager>();
        //print(GameManager.lives);
        //bgm = GameObject.Find("bgm").GetComponent<AudioSource>();
        //overMusic = GameObject.Find("OverMusic")..GetComponent<AudioSource>();
        heartsImg = GameObject.Find("hearts").GetComponent<Image>();
        baseNave = GameObject.Find("baseNave");
        dedScreen = GameObject.Find("DedScreen");
        explotion = Resources.Load("prefabs/effects/Explotion1") as GameObject;
        SpeedCounter = GameObject.Find("speedCount").GetComponent<Text>();
        moveShip = baseNave.GetComponent<MoveShip>();
        heartsImg.sprite = heartsSprt[GameManager.lives];
    }
    void Start()
    {
        GameManager.score = 0;
        dedScreen.SetActive(false);
        StartCoroutine("ScoreGiver");
        StartCoroutine("SpeedManage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) pause();
    }
    public void hitFunction()
    {
        //Comprovaci�n de vidas, si quedan recarga la escena, si no hay saca mensaje de game over
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
        heartsImg.sprite = heartsSprt[GameManager.lives];
        print("Hit");
    }

    private void gameOver()
    {
        Destroy(baseNave);
        Instantiate(explotion, baseNave.transform.position, Quaternion.identity);
        //bgm.enabled = false;
        //overMusic.enabled = true;
        StopCoroutine("ScoreGiver");
        StopCoroutine("SpeedManage");
        dead = true;
        heartsImg.enabled = false;
        //Comprovaci�n del score
        if (GameManager.score > GameManager.highScore)
        {
            GameManager.highScore = GameManager.score;
            GameManager.newBest = true;
        }
        //print(GameManager.score);

        dedScreen.SetActive(true);
        print("game over");
        //SceneManager.LoadScene("Screen1");
    }

    public void pause()
    {
        if (!paused)
        {
            print("paused");
            paused = true;
            Time.timeScale = 0;
        }
        else
        {
            print("resumed");
            Time.timeScale = 1;
            paused = false;
        }
    }

    IEnumerator ScoreGiver()
    {
        while (!dead)
        {
            GameManager.score += (int) speed / 30;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SpeedManage()
    {
        while(!dead)
        {
            speed += accelNum;
            //Shader.SetGlobalVector("Vector2_f037d501af714dff8c4ee7609ccef207", Vector2.down * Uvelocity);
            if (moveShip.latSpeed < 40) moveShip.latSpeed += 5;
            SpeedCounter.text = "Speed: "+speed;
            //print("más velocidad");
            yield return new WaitForSeconds(accelTime);
        }
    }
}
