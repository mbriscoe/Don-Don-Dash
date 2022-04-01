using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameOver;
    public float speed;
    public int score;
    public int highScore;

    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI speedDisplay;
    public TextMeshProUGUI highScoreDisplay;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        gameOver = false;
        speed = 1;
        score = 0;
        highScore = 0;

        scoreDisplay.SetText("Score: " + score);
        speedDisplay.SetText("Speed: " + speed);
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreDisplay.SetText("High Score: " + highScore);
    }

    public void UpdateScore()
    {
        score += 1;
        scoreDisplay.SetText("Score: " + score);

        if(highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            highScoreDisplay.SetText("High Score: " + highScore);
        }

        if (score % 5 == 0)
        {
            UpdateSpeed();
        }
    }

    private void UpdateSpeed()
    {
        speed += 1;
        speedDisplay.SetText("Speed: " + speed);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Main") return;
        
        scoreDisplay = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
        speedDisplay = GameObject.Find("speedText").GetComponent<TextMeshProUGUI>();
        highScoreDisplay = GameObject.Find("highScoreText").GetComponent<TextMeshProUGUI>();
        scoreDisplay.SetText("Score: " + score);
        speedDisplay.SetText("Speed: " + speed);

        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreDisplay.SetText("High Score: " + highScore);
    }
}
