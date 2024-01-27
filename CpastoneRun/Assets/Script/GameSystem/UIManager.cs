using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public static bool IsPaused = false;
    public GameObject escapeMenu;
    public GameObject gameOverMenu;
    public GameObject ingameUI;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI recordText;

    void Update()
    {
        // 스코어 텍스트 구현
        if (!GameManager.Instance.isGameover)
        {
            GameManager.Instance.score += Time.deltaTime;
            scoreText.text = "SCORE\n" + (int)GameManager.Instance.score;
        }

        // 인게임 esc 클릭시 메뉴창 on/off 기능
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == false)
            {
                escapeMenu.SetActive(true);
                Time.timeScale = 0f;
                IsPaused = true;
            }
            else
            {
                escapeMenu.SetActive(false);
                Time.timeScale = 1f;
                IsPaused = false;
            }
        }

        // 플레이어 사망시 gameover메뉴
        if(GameManager.Instance.isGameover)
        {
            // 게임화면 멈춤
            Time.timeScale = 0f;
            IsPaused = true;

            //gameover메뉴 활성화
            gameOverMenu.SetActive(true);

            //인게임 UI 비활성화
            ingameUI.SetActive(false);

            //개인 기록
            recordText.text = "Record : " + (int)GameManager.Instance.score;

            //개인 기록이 랭킹보드 기록보다 높으면 내림차순으로 랭킹보드 최신화
            if ( GameManager.Instance.score > GameManager.Instance.rankingBoard[0])
            {
                GameManager.Instance.rankingBoard[0] = GameManager.Instance.score;
                Array.Sort(GameManager.Instance.rankingBoard);
                for(int i = 0; i < 3; i++)
                {
                    Debug.Log(GameManager.Instance.rankingBoard[i] + " ");
                }
                PlayerPrefs.SetFloat("First", GameManager.Instance.rankingBoard[2]);
                PlayerPrefs.SetFloat("Second", GameManager.Instance.rankingBoard[1]);
                PlayerPrefs.SetFloat("Third", GameManager.Instance.rankingBoard[0]);
            }

            GameManager.Instance.init();

        }
    }



    // esc메뉴/gameover메뉴 버튼별 기능
    public void OnClickedNewGame()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.Instance.init();
        ingameUI.SetActive(true);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    public void OnClickedResume()
    {
        escapeMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void OnClickedMainMenu()
    {
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.init();
        ingameUI.SetActive(true);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
