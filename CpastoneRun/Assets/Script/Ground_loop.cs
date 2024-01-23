using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_loop : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, 58);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -8)
        {
            transform.position = transform.position + offset;
        }
    }
}
