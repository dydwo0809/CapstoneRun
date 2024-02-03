using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject subItemPrefab; // 생성할 아이템 프리팹
    public GameObject addItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
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

            //아이템이 1/5 확률로 활성화됨
            if (Random.Range(0, 2) == 1)
            {
                if (Random.Range(0, 2) == 1)
                {
                    Debug.Log("subItem is activated");
                    GameObject subItem = Instantiate(subItemPrefab, transform.position, transform.rotation);
                    Vector3 start_position = new Vector3(Random.Range(-1, 2) * 4, 1.5f, 78);
                    subItem.transform.position = start_position;

                }
                else
                {
                    Debug.Log("addItem is activated");
                    GameObject addItem = Instantiate(addItemPrefab, transform.position, transform.rotation);
                    Vector3 start_position = new Vector3(Random.Range(-1, 2) * 4, 1.5f, 78);
                    addItem.transform.position = start_position;
                }
            }

            transform.position = new Vector3(0, 0, 0);
        }
    }
}
