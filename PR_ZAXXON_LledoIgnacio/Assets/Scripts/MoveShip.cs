using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float latSpeed = 20;
    private Vector3 initialPos = new Vector3 (0f,0f,0f);
    private Vector3 initialRot = new Vector3 (0, 0, 0);
    private Vector3 movePos = new Vector3 (0f, 0f, 0f);
    private Vector3 moveRot = new Vector3 (0, 0, 0);
    private Vector3 rightMove = new Vector3 (1f, 0f, 0f);
    private Vector3 leftMove = new Vector3 (-1f,0f,0f);
    private Vector3 upMove = new Vector3 (0f,1f,0f);
    private Vector3 downMove = new Vector3 (0f,-1f,0f);
    private Vector3 leftSpin = new Vector3 (0,0,120);
    private Vector3 rightSpin = new Vector3 (0,0,-120);
    GameFunctions gameFunctions;
    //m�todo para restringir la posici�n en un eje
    public void limitSpace(int x, float lim, bool superior = true)
    {
        //si el l�mite es por arriba
        if (superior)
        {
            if (movePos[x] <= lim)
            {
                transform.position = movePos;
            }
            else
            {
                movePos = transform.position;
            }
        }
        //si el l�mite es por abajo
        else
        {
            if (movePos[x] >= lim)
            {
                transform.position = movePos;
            }
            else
            {
                movePos = transform.position;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameFunctions = GameObject.Find("gameOperator").GetComponent<GameFunctions>();
        transform.position = initialPos;
        transform.eulerAngles = initialRot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //desplazamiento a la izquierda
            movePos += leftMove * latSpeed * Time.deltaTime;
            //rotaci�n del movimiento
            moveRot += leftSpin * Time.deltaTime;
            //restricci�n de rotaci�n
            if (moveRot[2] < 35)
            {
                transform.eulerAngles = moveRot;
            }
            else
            {
                moveRot[2] = 35;
            }
            //restricci�n de area
            limitSpace(0, -20, false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //despalzamiento a la derecha
            movePos += rightMove * latSpeed * Time.deltaTime;
            //rotaci�n del moviento
            moveRot += rightSpin * Time.deltaTime;
            //restricci�n de rotaci�n
            if (moveRot[2] > -35)
            {
                transform.eulerAngles = moveRot;
            }
            else
            {
                moveRot[2] = -35;
            }
            //restricci�n de area
            limitSpace(0, 20);
        }
        if (Input.GetKey(KeyCode.W))
        {
            //desplazamiento hacia arriba
            movePos += upMove * latSpeed * Time.deltaTime;
            //restricci�n de area
            limitSpace(1, 14);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //desplazamiento hacia arriba
            movePos += downMove * latSpeed * Time.deltaTime;
            //restricci�n de area
            limitSpace(1, -1, false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print("colisi�n");
        if(other.gameObject.tag == "Obstacle")
        {
            print("obst�culo");
            gameFunctions.hitFunction();
        }
    }
}