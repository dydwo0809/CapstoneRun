using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.addScore(0.1f);
        float score = GameManager.Instance.score;
        //Debug.Log(score);
    }
}
