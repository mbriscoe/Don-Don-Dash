
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour {
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalSpeedText;
    public TextMeshProUGUI finalHighScoreText;

    // Start is called before the first frame update
    private void Start() {
        finalScoreText.SetText("Score: " + GameManager.instance.score);
        finalSpeedText.SetText("Speed: " + GameManager.instance.speed);
        finalHighScoreText.SetText("High Score: " + PlayerPrefs.GetInt("highScore", 0));
    }
}
