using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePillar : MonoBehaviour
{
    private MoveShip moveShip;
    private Vector3 moveBack = new Vector3(0, 0, -4);
    // Start is called before the first frame update
    void Start()
    {
        moveShip = GameObject.Find("baseNave").GetComponent<MoveShip>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > -55)
        {
            transform.position += moveBack * moveShip.speed * Time.deltaTime;
        }
        
    }
}
