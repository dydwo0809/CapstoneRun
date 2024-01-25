using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{
    private Vector3 pos;
    private float max = 0.3f;
    private float speed = 2f;
    private float x = 0;
    void Start()
    {
        transform.rotation = Quaternion.identity;
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.y += max * Mathf.Sin(Time.time * speed);
        transform.position = v;
        x += Time.deltaTime * 50;
        transform.rotation = Quaternion.Euler(0, x, 0);
    }

    // Update is called once per frame
    void OnTriggrEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.addItemScore(5f);
            Destroy(gameObject);
        }
    }
}
