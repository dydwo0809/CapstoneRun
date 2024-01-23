using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    private float cube_size=4;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -15)
        {
            //reposition
            Vector3 offset = new Vector3(0, 0, 100);
            transform.position = transform.position + offset;
        }
    }
}
