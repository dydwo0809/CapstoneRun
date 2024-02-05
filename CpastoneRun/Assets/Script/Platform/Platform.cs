using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject[] platforms; // 발판을 구성하는 갯수



    void Start()
    {
    }

    void Update()
    {
    }

    private void OnEnable()
    {
        //플랫폼 오브젝트가 다시 활성화 되면
        //Debug.Log("Platform is activated");

        for (int i = 0; i < platforms.Length; i++)
        {
            //바닥 하나당 1/3 확률로 비활성화 됨
            if (Random.Range(0, 3) == 1)
            {
                platforms[i].SetActive(false);
            }
            else
            {
                platforms[i].SetActive(true);
            }
        }


    }

}
