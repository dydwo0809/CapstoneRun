using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<GameManager>();
                if (!_instance)
                {
                    GameObject obj = new GameObject();
                    obj.name = "GameManager";
                    _instance = obj.AddComponent(typeof(GameManager)) as GameManager;
                }
            }
            return _instance;
        }
    }
    public float score { get; set; } = 0;
    public int level { get; set; } = 1;
    public float[] rankingBoard = new float[3];
    public bool isGameover = false;

    public float forceGravity = 25f;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        rankingBoard[0] = PlayerPrefs.GetFloat("Third", 0);
        rankingBoard[1] = PlayerPrefs.GetFloat("Second", 0);
        rankingBoard[2] = PlayerPrefs.GetFloat("First", 0);

        Physics.gravity = new Vector3(0, -forceGravity, 0);
    }

    public void addItemScore(float added)
    {
        score += added;
    }

    public void init()
    {
        score = 0;
        level = 1;
        isGameover = false;
    }
}
