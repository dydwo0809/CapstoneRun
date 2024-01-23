using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    Transform cube_transform;
    public float speed = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        cube_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cube_transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
