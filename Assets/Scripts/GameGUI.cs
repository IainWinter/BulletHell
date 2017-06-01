using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGUI : MonoBehaviour {
    public AnimatedScore animatedScore;
    public GameManager gameManager;
    public Text health;
    public Text score;
    public Text gameOver;
    public Text reset;
    public Text levelCount;

    void Start() {
        gameOver.gameObject.SetActive(false);
    }

    void Update() {
        if (gameManager.isResetting) {
            gameOver.gameObject.SetActive(false);
            reset.gameObject.SetActive(false);
        } else if (gameManager.player != null) {
            score.text = animatedScore.score.ToString("0000000000");
            health.text = "+" + gameManager.player.GetComponent<Damageable>().health;
            levelCount.text = "l" + gameManager.currentLevelIndex.ToString("000");
        } else {
            health.text = "+0";
            gameOver.gameObject.SetActive(true);
            reset.gameObject.SetActive(true);
        }
    }

    public void AddScoreAnimation(int score) {
        animatedScore.AddScore(score);
    }

    public void Reset() {
        gameOver.gameObject.SetActive(false);
        reset.gameObject.SetActive(false);
    }
}
