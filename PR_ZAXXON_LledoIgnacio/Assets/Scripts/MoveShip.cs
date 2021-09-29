using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public int speed = 18;
    private Vector3 initialPos = new Vector3 (0f,0f,0f);
    private Vector3 initialRot = new Vector3 (0, 0, 0);
    private Vector3 movePos = new Vector3 (0f, 0f, 0f);
    private Vector3 moveRot = new Vector3 (0f, 0f, 0f);
    private Vector3 rightMove = new Vector3 (1f, 0f, 0f);
    private Vector3 leftMove = new Vector3 (-1f,0f,0f);
    private Vector3 leftSpin = new Vector3 (0,0,40);
    private Vector3 rightSpin = new Vector3 (0,0,-40);
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
            movePos += leftMove * speed * Time.deltaTime;
            transform.eulerAngles += leftSpin * Time.deltaTime;
            if(movePos[0] >= -20)
            {
                transform.position = movePos;
            }
            else
            {
                movePos = transform.position;
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            movePos += rightMove * speed * Time.deltaTime;
            transform.eulerAngles += rightSpin * Time.deltaTime;
            if (movePos[0] <= 20)
            {
                transform.position = movePos;
            }
            else
            {
                movePos = transform.position;
            }
        }
    }
}
