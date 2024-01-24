using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EscapeMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject escapeMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused == false)
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
    }

    public void OnClickedNewGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void OnClickedMainMenu()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
        IsPaused = false;
    }

}
