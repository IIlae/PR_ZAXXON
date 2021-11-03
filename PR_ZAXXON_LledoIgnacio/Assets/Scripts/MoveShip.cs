using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public int speed = 18;
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
    //método para restringir la posición en un eje
    public void limitSpace(int x, float lim, bool superior = true)
    {
        //si el límite es por arriba
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
        //si el límite es por abajo
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
            movePos += leftMove * speed * Time.deltaTime;
            //rotación del movimiento
            moveRot += leftSpin * Time.deltaTime;
            //restricción de rotación
            if (moveRot[2] < 35)
            {
                transform.eulerAngles = moveRot;
            }
            else
            {
                moveRot[2] = 35;
            }
            //restricción de area
            limitSpace(0, -20, false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //despalzamiento a la derecha
            movePos += rightMove * speed * Time.deltaTime;
            //rotación del moviento
            moveRot += rightSpin * Time.deltaTime;
            //restricción de rotación
            if (moveRot[2] > -35)
            {
                transform.eulerAngles = moveRot;
            }
            else
            {
                moveRot[2] = -35;
            }
            //restricción de area
            limitSpace(0, 20);
        }
        if (Input.GetKey(KeyCode.W))
        {
            //desplazamiento hacia arriba
            movePos += upMove * speed * Time.deltaTime;
            //restricción de area
            limitSpace(1, 14);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //desplazamiento hacia arriba
            movePos += downMove * speed * Time.deltaTime;
            //restricción de area
            limitSpace(1, -1, false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print("colisión");
        if(other.gameObject.tag == "Obstacle")
        {
            print("obstáculo");
            gameFunctions.gameOver();
        }
    }
}