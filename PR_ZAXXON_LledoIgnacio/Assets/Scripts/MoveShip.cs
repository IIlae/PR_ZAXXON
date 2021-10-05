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
    private Vector3 leftSpin = new Vector3 (0,0,120);
    private Vector3 rightSpin = new Vector3 (0,0,-120);
    // Start is called before the first frame update
    void Start()
    {
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
            moveRot[2] += leftSpin[2] * Time.deltaTime;
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
            if (movePos[0] >= -20)
            {
                transform.position = movePos;
            }
            else
            {
                movePos = transform.position;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            //despalzamiento a la derecha
            movePos += rightMove * speed * Time.deltaTime;
            //rotación del moviento
            moveRot[2] += rightSpin[2] * Time.deltaTime;
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
            if (movePos[0] <= 20)
            {
                transform.position = movePos;
            }
            else
            {
                movePos = transform.position;
            }
        }
        //print(moveRot[2]);
    }
}
