using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] cubes; // 발판을 구성하는 큐브의 갯수
    public GameObject[] items;//

    //private bool stepped = false; // 플레이어 캐릭터가 밟았었는가

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnEnable()
    {
        //오브젝트가 다시 활성화 되면
        Debug.Log("activated");

        //stepped = false; //밟힘 상태 리셋


        for (int i=0; i<cubes.Length; i++)
        {
            //발판 하나당 1/3 확률로 활성화 됨
            if (Random.Range(0,3) == 0)
            {
                cubes[i].SetActive(false);
            }
            else
            {
                cubes[i].SetActive(true);  
            }

            //아이템은 1/4 확률로 활성화 됨
            if (Random.Range(0, 4) == 0)
            {
                items[i].SetActive(true);
            }
            else
            {
                items[i].SetActive(false);
            }

        }
    }

    //플레이어 캐릭터가 발판을 밟았을때 점수를 추가하는 처리 -> 우선 시간과 아이템으로만 점수를 계산하는 것 같아서 주석 처리 해놓
    //void OnCollisionEnter(Collision collision)
    //{
    //    //플레이어 태그를 가지고 있는 오브젝트와 충돌했고 stepped 가 false 라면
    //    if (collision.collider.tag == "Player" && !stepped)
    //    {
    //        stepped = true;
    //        GameManager.Instance.score += 1;
    //    }
    //}
}
