using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMaker : MonoBehaviour
{
    private Vector3 obsInitPos = new Vector3(0f, 28.9f, 207f);
    private MoveShip moveShip;
    private GameFunctions gameFunctions;
    [SerializeField] GameObject[] obstacArr = {GameObject.Find("basePilar"), GameObject.Find("baseSaliente")};
    float intervalo;
    float espaciado = 25f;
    // Start is called before the first frame update
    void Start()
    {
        espaciado = 25f;
        moveShip = GameObject.Find("baseNave").GetComponent<MoveShip>();
        gameFunctions = GameObject.Find("gameOperator").GetComponent<GameFunctions>();
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
            intervalo = espaciado / moveShip.speed;
            //print(espaciado + "/" + moveShip.speed + "=" + intervalo);
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
