using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public GameObject enemySpawnPrefab;

    public static int score = 0;
    public static int lives = 3;
    public static float enemySpawnCooldown = 5.0f;
    public static float playerShootCooldown = 1.0f;

    private int updatedAt = -1;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemySpawns();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + score.ToString());
        livesText.SetText("Lives: " + lives.ToString());
        UpdateEnemySpawnCdIfNecessary();
        CheckLives();
    }

    private void GenerateEnemySpawns()
    {
        int screenWidth = Screen.width;
        int screenHeigtht = Screen.height;

        Instantiate(enemySpawnPrefab, Camera.main.ViewportToWorldPoint(new Vector3(-0.25f, -0.25f, 10)), Quaternion.identity); // Left-bottom (0,0)
        Instantiate(enemySpawnPrefab, Camera.main.ViewportToWorldPoint(new Vector3(1.25f, -0.25f, 10)), Quaternion.identity); // Right-bottom (1,0)
        Instantiate(enemySpawnPrefab, Camera.main.ViewportToWorldPoint(new Vector3(1.25f, 1.25f, 10)), Quaternion.identity); // Right-top (1,1)
        Instantiate(enemySpawnPrefab, Camera.main.ViewportToWorldPoint(new Vector3(-0.25f, 1.25f, 10)), Quaternion.identity); // Left-top (0,1)

    }

    private void UpdateEnemySpawnCdIfNecessary()
    {
        if (score % 500 == 0 && score != 0 && updatedAt != score)
        {
            updatedAt = score;
            enemySpawnCooldown = enemySpawnCooldown - 0.2f;
            playerShootCooldown = playerShootCooldown - 0.1f;
        }
    }

    private void CheckLives()
    {
        if (lives == 0)
        {
            // GAME OVER
        }
    }
}
