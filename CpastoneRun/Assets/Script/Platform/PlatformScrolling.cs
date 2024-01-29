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
            if(transform.position.z <= -12)
            {
                gameObject.SetActive(false);
                gameObject.SetActive(true);
                transform.position = new Vector3(0, 0, 60);
            }
            transform.Translate(Vector3.back * platformScrollingSpeed * Time.deltaTime);

        }

    }
}
