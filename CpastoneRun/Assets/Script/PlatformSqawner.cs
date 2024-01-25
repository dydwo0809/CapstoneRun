using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSqawner : MonoBehaviour
{

    public GameObject[] platforms; // 미리 생성돼있는 플랫폼들

    private float timeSpawnMin = 0.5f; // 다음 배치까지의 시간 간격 최솟값
    private float timeSpawnMax = 1.0f; // 다음 배치까지의 시간 간격 최댓값
    private float timeBetSpawn; // 다음 배치까지의 시간 간격

    public float xMin = -25f; // 배치할 위치의 최소 x값
    public float xMax = 25f; // 배치할 위치의 최대 x값

    private int currentPlatformIdx=0;

    private Vector3 poolPosition = new Vector3(-20, 0, -10); //pool의 위치
    private float lastSpawnTime; 

    void Start()
    {
        lastSpawnTime = 0f;//마지막 배치 시점 초기화
        timeBetSpawn = 0f; //다음번 배치까지의 시간 간격을 0으로 초기화 -> 게임이 시작되자마자 지연시간 없이 즉시 첫번째 발판이 생성
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버 상태에서는 동작하지 않음
        //if (GameManager.instance.isGameover)
        //{
        //    return;
        //}

        // 마지막 배치 시점에서 timeBetSpawn이상 시간이 흘렀다면
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time; //현재 시간 기
            timeBetSpawn = Random.Range(timeSpawnMin, timeSpawnMax);
            float xPos = Random.Range(xMin, xMax);

            //사용할 현재 순번의 발판 게임오브젝트 활성화 -> OnEnable메서드가 실행됨(군데군데 랜덤 생3)
            platforms[currentPlatformIdx].SetActive(true);

            //현재 순번의 발판을 화면 오른쪽에 재배치
            platforms[currentPlatformIdx].transform.position = new Vector3(xPos,0,25);

            currentPlatformIdx++;

            if (currentPlatformIdx >= platforms.Length)
            {
                currentPlatformIdx = 0;
            }
        }

    }
}
