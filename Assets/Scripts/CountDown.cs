using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using IwTools;

public class CountDown : MonoBehaviour {
    public Text countDownText;
    private ElapsedTime timer;

    public GameObject player;
    public GameManager gameManager;

    void Start() {
        player.transform.localScale = Vector3.zero;
        timer = new ElapsedTime();

        countDownText.text = "Level " + gameManager.currentLevelIndex;
    }

    void Update() {
        if (timer.MillisSince() > 500 * Time.timeScale) {
            player.GetComponent<Animation>().Play();
        }

        if (timer.MillisSince() > 1000 * Time.timeScale) {
            Destroy(gameObject);
        }
    }
}
