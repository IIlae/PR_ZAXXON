using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRemover : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("remover");
    }

    void Update()
    {
        
    }
    IEnumerator remover()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.5f);
            //print("adios");
            Destroy(this.gameObject);
        }
    }
}
