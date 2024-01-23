using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_scrolling : MonoBehaviour
{
    public float speed = 20f;
    public float speed_raiseRate = 0.1f;

    float score = GameManager.Instance.score;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speed += speed_raiseRate * score;
        transform.Translate(Vector3.back* speed * Time.deltaTime);

    }
}
