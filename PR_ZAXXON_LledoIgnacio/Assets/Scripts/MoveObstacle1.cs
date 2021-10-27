using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle1 : MonoBehaviour
{
    private MoveShip moveShip;
    private Vector3 moveBack = new Vector3(0, 0, -4);
    GameFunctions gameFunctions = GameObject.Find("gameOperator").GetComponent<GameFunctions>();
    // Start is called before the first frame update
    void Start()
    {
        moveShip = GameObject.Find("baseNave").GetComponent<MoveShip>();
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            if (transform.position.z > -55)
            {
                transform.position += moveBack * moveShip.speed * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
