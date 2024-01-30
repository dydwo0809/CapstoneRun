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
        firstText.text = "1. " + (int)PlayerPrefs.GetFloat("First");
        secondText.text = "2. " + (int)PlayerPrefs.GetFloat("Second");
        thirdText.text = "3. " + (int)PlayerPrefs.GetFloat("Third");
    }
    public void OnClickedBackToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

}
