using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSqawner : MonoBehaviour
{
    public GameObject platformPrefab; // 생성할 발판의 원본 프리팹
    public int count = 16; // 생성할 발판의 개수 == 길이 4개 이상으로 해야합니다 

    private GameObject[] platforms; // 미리 생성돼있는 플랫폼들

    private int currentPlatformIdx=0; // 현재 사용할 순서의 발

    void Start()
    {
        // 변수들을 초기화하고 사용할 발판들을 미리 생성

        //count 만큼의 공간을 가지는 새로운 발판 배열 생
        platforms = new GameObject[count];

        // count 만큼 루프하면서 발판 생성
        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, new Vector3(0,0,6 * (i-3)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버 상태에서는 동작하지 않음
        if (GameManager.Instance.isGameover)
        {
            return;
        }

        // 마지막 배치 시점에서 timeBetSpawn이상 시간이 흘렀다면
        if (transform.position.z <= -6)
        {
            //사용할 현재 순번의 발판 게임오브젝트를 비활성화하고 즉시 다시 활성화 -> OnEnable메서드가 실행됨
            platforms[currentPlatformIdx].SetActive(false);
            platforms[currentPlatformIdx].SetActive(true);

            //현재 순번의 발판 재배치
            platforms[currentPlatformIdx].transform.position = new Vector3(0,0,6*(count-3));

            currentPlatformIdx++;

            if (currentPlatformIdx >= count)
            {
                currentPlatformIdx = 0;
            }
            transform.position = new Vector3(0, 0, 0);
        }

    }
}
