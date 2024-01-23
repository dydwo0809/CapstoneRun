using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_upDown : MonoBehaviour
{
    public float moveRateMin = 3f; //최소 움직임 주기
    public float moveRateMax = 5f; //최대 움직임 주기

    private float moveRate; //움직임 주기
    private float timeAfterMove;//최근 움직 시점에서 지난 시간

    private Vector3 offset = new Vector3(0, 10, 0);

    // Start is called before the first frame update
    void Start()
    {
        timeAfterMove = 0f;
        moveRate = Random.Range(moveRateMin, moveRateMax);

    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterMove갱신
        timeAfterMove += Time.deltaTime;
        Debug.Log(timeAfterMove);
    

        //moveRate을 넘어서면
        if (timeAfterMove >= moveRate)
        {
            timeAfterMove = 0f; // timeAfterMove초기화

            //아래로 내려간건 올라가고 올라간건 내려가고
            if (transform.position.y == 0)
            {
                transform.position = transform.position - offset;
            }
            else
            {
                transform.position = transform.position + offset;
            }
            moveRate = Random.Range(moveRateMin, moveRateMax);//다음 생성간격 랜덤으로 지정
        }

    }
}
