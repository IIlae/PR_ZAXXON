using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePillar : MonoBehaviour
{
    public GameObject baseNave;
    private MoveShip MoveShip;
    private Vector3 moveBack = new Vector3(0, 0, -60);
    // Start is called before the first frame update
    void Start()
    {
        MoveShip = baseNave.GetComponent<MoveShip>();
    }

    // Update is called once per frame
    void Update()
    {
        while (transform.position.z > -55)
        {
            transform.position += moveBack * MoveShip.speed * Time.deltaTime;
        }
        
    }
}
