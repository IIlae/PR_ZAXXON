using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMaker : MonoBehaviour
{
    private Vector3 obsInitPos = new Vector3(0f,29f,207f);
    private MoveShip moveShip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveShip = GameObject.Find("baseNave").GetComponent<MoveShip>();
        StartCoroutine("ObstacleMake");
    }

    IEnumerator ObstacleMake()
    {
        while (true)
        {

        }
    }
}
