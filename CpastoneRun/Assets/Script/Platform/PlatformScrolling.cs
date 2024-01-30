using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScrolling : MonoBehaviour
{
    public float platformScrollingSpeed = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //게임이 안끝났을때만 이동
        if (!GameManager.Instance.isGameover)
        {
            transform.Translate(Vector3.back * platformScrollingSpeed * Time.deltaTime);
        }

    }
}
