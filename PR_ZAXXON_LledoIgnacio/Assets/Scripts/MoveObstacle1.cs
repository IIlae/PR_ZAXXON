using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle1 : MonoBehaviour
{
    MoveShip moveShip;
    //private Vector3 moveBack = new Vector3(0, 0, -4);
    GameFunctions gameFunctions;
    // Start is called before the first frame update
    void Start()
    {
        moveShip = GameObject.Find("baseNave").GetComponent<MoveShip>();
        gameFunctions = GameObject.Find("gameOperator").GetComponent<GameFunctions>();
        //print(gameFunctions.dead);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameFunctions.dead)
        {
            if (transform.position.z > -55)
            {
                transform.position += Vector3.back * gameFunctions.speed * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Nave")
        {
            Instantiate(Resources.Load("prefabs/effects/Explotion2"), transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}
