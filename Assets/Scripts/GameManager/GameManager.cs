using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public GameObject enemySpawnPrefab;

    public static float score = 0;
    public static int lives = 3;
    public static float enemySpawnCooldown = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemySpawns();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + score.ToString());
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
}
