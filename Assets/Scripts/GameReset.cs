using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour {
    public GameManager gameManager;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
            gameManager.ResetLevel();
		}
	}
}
