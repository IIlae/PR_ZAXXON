using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMaker : MonoBehaviour
{
    private Vector3 obsInitPos = new Vector3(0f, 28.9f, 207f);
    private MoveShip moveShip;
    private GameFunctions gameFunctions;
    [SerializeField] GameObject[] obstacArr;
    float intervalo;
    float espaciado;
    private void Awake()
    {
        moveShip = GameObject.Find("baseNave").GetComponent<MoveShip>();
        gameFunctions = GameObject.Find("gameOperator").GetComponent<GameFunctions>();
        for(int x = 0; x < obstacArr.Length; x++)
        {
            //print("instanciado " + 1);
            obstacArr[x] = Resources.Load("prefabs/obstacles/obstacle" + x) as GameObject;
        }
    }
    void Start()
    {
        espaciado = 40f;
        StartCoroutine("ObstacleMake");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ObstacleMake()
    {
        //print("coroutine Started");
        Vector3 instPos;
        while (!gameFunctions.dead)
        {
            intervalo = espaciado / gameFunctions.speed;
            //print(espaciado + "/" + gameFunctions.speed + "=" + intervalo);
            int randObs = Random.Range(0, obstacArr.Length);
            float yValue;
            if (randObs == 0)
            {
                yValue = 28.9f;
            }
            else
            {
                yValue = 0.72f;
            }
            instPos = new Vector3(Random.Range(20,-20), yValue, 207);
            Instantiate(obstacArr[randObs], instPos, Quaternion.identity);
            //print("instanciado");
            yield return new WaitForSeconds(intervalo);
        }
    }
}
