using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingBoard : MonoBehaviour
{
    public TextMeshProUGUI firstText;
    public TextMeshProUGUI secondText;
    public TextMeshProUGUI thirdText;
    void Start()
    {
        firstText.text = "1. " + (int)PlayerPrefs.GetFloat("First", 0);
        secondText.text = "2. " + (int)PlayerPrefs.GetFloat("Second", 0);
        thirdText.text = "3. " + (int)PlayerPrefs.GetFloat("Third", 0);
    }
    public void OnClickedBackToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

}
