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
        // ���ھ� �ؽ�Ʈ ����
        if (!GameManager.Instance.isGameover)
        {
            GameManager.Instance.score += Time.deltaTime;
            scoreText.text = "SCORE\n" + (int)GameManager.Instance.score;
        }

        // �ΰ��� esc Ŭ���� �޴�â on/off ���
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

        // �÷��̾� ����� gameover�޴�
        if(GameManager.Instance.isGameover)
        {
            // ����ȭ�� ����
            Time.timeScale = 0f;
            IsPaused = true;

            //gameover�޴� Ȱ��ȭ
            gameOverMenu.SetActive(true);

            //�ΰ��� UI ��Ȱ��ȭ
            ingameUI.SetActive(false);

            //���� ���
            recordText.text = "Record : " + (int)GameManager.Instance.score;

            //���� ����� ��ŷ���� ��Ϻ��� ������ ������������ ��ŷ���� �ֽ�ȭ
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



    // esc�޴�/gameover�޴� ��ư�� ���
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
