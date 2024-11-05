using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text ScoreText;

    public GameObject GameOver;

    private static GameController instance;

    public static GameController Instance { get => instance; set => instance = value; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void UpdateScoreText()
    {
        ScoreText.text = totalScore.ToString();
    }
}

    
    
