using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSqawner : MonoBehaviour
{

    public GameObject[] platforms; // 미리 생성돼있는 플랫폼들

    private int currentPlatformIdx=0;

    void Start()
    {

    }

    void Update()
    {
        //게임 오버 상태에서는 동작하지 않음
        if (GameManager.Instance.isGameover)
        {
            return;
        }

        //발판 두개씩 생
        if (transform.position.z <= -12) 
        {

            //사용할 현재 순번의 발판 게임오브젝트 활성화 -> OnEnable메서드가 실행됨(군데군데 랜덤 생성)
            platforms[currentPlatformIdx].SetActive(false);
            platforms[currentPlatformIdx].SetActive(true);

            //현재 순번의 발판을 화면 재배치
            platforms[currentPlatformIdx].transform.position = new Vector3(0,0,(platforms.Length-1)*6);
            currentPlatformIdx++;


            if (currentPlatformIdx >= platforms.Length)
            {
                currentPlatformIdx = 0;
            }

            transform.position = new Vector3(0, 0, -6);
        }

    }
}
