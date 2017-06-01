using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using IwTools;

public class AnimatedScore : MonoBehaviour {
    public int score;
    private int scoreToBeAdded;

    public Object newScoreAnimationPrefab;
    public Canvas destinationCanvas;

    private ElapsedTime elapsedTime;
    private bool addScore;

    public void AddScore(int score) {
        addScore = true;
        elapsedTime.Update();
        scoreToBeAdded += score;

        GameObject newScoreAnimation = (GameObject)Instantiate(newScoreAnimationPrefab);
        newScoreAnimation.transform.SetParent(destinationCanvas.transform, false);
        newScoreAnimation.GetComponent<Text>().text = score + "";
    }

    void Start() {
        elapsedTime = new ElapsedTime();
    }

    void Update() {
        if (addScore && elapsedTime.MillisSinceUpdate() > 750) {
            addScore = false;
            score += scoreToBeAdded;
            scoreToBeAdded = 0;
        }
    }
}
