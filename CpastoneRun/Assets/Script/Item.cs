using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{
    private Rigidbody itemRigidbody;
    private Vector3 pos;
    private float max = 0.3f;
    private float speed = 2f;
    private float x = 0;
    void Start()
    {
        itemRigidbody = GetComponent<Rigidbody>();
        itemRigidbody.rotation = Quaternion.identity;
        pos = itemRigidbody.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.y += max * Mathf.Sin(Time.time * speed);
        itemRigidbody.position = v;
        x += Time.deltaTime * 50;
        itemRigidbody.rotation = Quaternion.Euler(0, x, 0);
    }

    // Update is called once per frame
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}



