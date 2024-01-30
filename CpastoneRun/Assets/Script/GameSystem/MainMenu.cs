using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickedStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnClickedRanking()
    {
        SceneManager.LoadScene("RankingBoardScene");
    }
    public void OnClickedQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
