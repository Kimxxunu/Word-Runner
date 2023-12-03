using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
    // Start is called before the first frame update
    void Start()
    {
        
    }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back*Time.deltaTime*2*15f);
    }
}
