using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using IwTools;

public class GameManager : MonoBehaviour {
    public GameGUI gameGui;

    [SerializeField] Object playerPrefab;
    public GameObject player;
    private PlayerController playerController;

    public Canvas destinationCanvas;
    [SerializeField] Object countDownObject;
    [SerializeField] GameObject countDown;

    private bool killBullets;
    private bool killEnemies;
    private bool resetLevel;
    public bool isResetting;

    public int currentLevelIndex;
    [SerializeField] GameObject currentLevel;
    [SerializeField] Level[] levels;

    private ElapsedTime elapsedTime;

    void Start() {
        player = SpawnPlayer();
        playerController = player.GetComponent<PlayerController>();
        SwitchLevelTo(currentLevelIndex);
        elapsedTime = new ElapsedTime();
    }

    void Update() {
        if (!resetLevel && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
            SwitchLevel();
        }

        //Reset
        if (killBullets) KillBullets();
        if (killEnemies) KillEnemies();
        if (resetLevel && GameObject.FindGameObjectsWithTag("DeathParticles").Length == 0) {
            isResetting = false;
            resetLevel = false;
            AddPoints(-10000);
            gameGui.Reset();
            SwitchLevelTo(currentLevelIndex - 1);
        }
    }

    private void KillBullets() {
        GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
        if (bullet != null) {
            if (elapsedTime.MillisSinceUpdate() > 5) {
                elapsedTime.Update();
                bullet.GetComponent<Damageable>().Damage(1);
            }
        } else {
            killBullets = false;
        }
    }

    private void KillEnemies() {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null) {
            if (elapsedTime.MillisSinceUpdate() > 5) {
                elapsedTime.Update();
                enemy.GetComponent<Damageable>().Damage(1);
            }
        } else {
            killEnemies = false;
        }
    }

    private GameObject SpawnPlayer() {
        GameObject go = (GameObject)Instantiate(playerPrefab, levels[currentLevelIndex].playerPos, Quaternion.Euler(Vector3.zero));
        go.GetComponent<PlayerController>().gameManager = this;
        return go;
    }

    private void SwitchLevelTo(int level) {
        currentLevelIndex = level;
        SwitchLevel();
    }

    private void SwitchLevel() {
        playerController.health = 5;

        killBullets = true;

        Destroy(player);
        player = SpawnPlayer();

        Destroy(GameObject.FindGameObjectWithTag("Level"));
        currentLevel = (GameObject)Instantiate(levels[currentLevelIndex].level);
        player.transform.position = levels[currentLevelIndex].playerPos;

        countDown = (GameObject)Instantiate(countDownObject);
        countDown.GetComponent<CountDown>().player = player;
        countDown.GetComponent<CountDown>().gameManager = this;
        countDown.transform.SetParent(destinationCanvas.transform, false);

        currentLevelIndex++;
    }

    public void AddPoints(int score) {
        gameGui.AddScoreAnimation(score);
    }

    public bool CanPlay() {
        return countDown == null && player != null && !player.GetComponent<Animation>().isPlaying;
    }

    public bool CanShoot() {
        if (isResetting) return false;
        if (player == null) return true;
        return countDown == null && !player.GetComponent<Animation>().isPlaying;
    }

    public void ResetLevel() {
        isResetting = true;
        killBullets = true;
        killEnemies = true;
        resetLevel = true;
    }
}

[System.Serializable]
public struct Level {
    public GameObject level;
    public Vector2 playerPos;
}
