using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore; // Pontuação atual
    public Text ScoreText; // Referência ao texto da pontuação

    public GameObject GameOver;
    public GameObject replayButton;

    private static GameController instance;

    public static GameController Instance { get => instance; set => instance = value; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AssignScoreText(); // Atribui o ScoreText na cena atual
        totalScore = StaticScore.keepValue; // Inicializa pontuação a partir de StaticScore
        UpdateScoreText(); // Atualiza o texto da pontuação
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignScoreText(); // Reatribui o ScoreText após carregar a cena
        totalScore = StaticScore.keepValue; // Sincroniza pontuação
        UpdateScoreText(); // Atualiza o texto da pontuação

        // Ativa ou desativa o botão de replay dependendo da cena
        if (scene.name == "Final")
        {
            if (replayButton != null)
            {
                replayButton.SetActive(true);
            }
        }
        else
        {
            if (replayButton != null)
            {
                replayButton.SetActive(false);
            }
        }
    }

    void AssignScoreText()
    {
        if (ScoreText == null)
        {
            GameObject scoreTextObject = GameObject.Find("Text");
            if (scoreTextObject != null)
            {
                ScoreText = scoreTextObject.GetComponent<Text>();
            }
        }
    }

    public void RestartGame()
    {
        totalScore = 0;
        StaticScore.keepValue = 0;

        AssignScoreText();

        if (ScoreText != null)
        {
            ScoreText.text = "0";
        }

        SceneManager.LoadScene("lvl_1");
    }

    public void UpdateScoreText()
    {
        if (ScoreText != null)
        {
            ScoreText.text = totalScore.ToString();
        }
    }

    public void AddScore(int points)
    {
        totalScore += points; // Adiciona pontos
        StaticScore.keepValue = totalScore; // Atualiza StaticScore para persistência
        UpdateScoreText(); // Atualiza o texto da pontuação
    }

    public void ResetScore()
    {
        totalScore = 0;
        StaticScore.keepValue = 0;

        UpdateScoreText();
    }
}
