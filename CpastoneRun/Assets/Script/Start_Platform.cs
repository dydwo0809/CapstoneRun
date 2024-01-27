using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Platform : MonoBehaviour
{
    public float platformScrollingSpeed = 10f;

    // Start is called before the first frame update
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

        if (transform.position.z <= -12)
        {
            gameObject.SetActive(false);

        }
    }
}
