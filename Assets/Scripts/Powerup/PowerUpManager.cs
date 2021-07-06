using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    Health,
    Explosion,
    EnemySlowDown,
}

public class PowerUpManager : MonoBehaviour
{
    public static bool isPowerUpSpawned = false;

    public float powerUpSpawnTime = 5.0f;
    public GameObject powerUpPrefab;

    private float _powerUpSpawnTime;


    // Start is called before the first frame update
    void Start()
    {
        _powerUpSpawnTime = powerUpSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPowerUpSpawned)
        {
            _powerUpSpawnTime -= Time.deltaTime;
            if (_powerUpSpawnTime < 0)
            {
                isPowerUpSpawned = true;

                ArrayList powerUpTypes = new ArrayList(new[] {PowerUpType.Explosion, PowerUpType.EnemySlowDown});

                if (GameManager.lives < 3)
                {
                    powerUpTypes.Add(PowerUpType.Health);
                }

                PowerUpType selectedPowerUp = (PowerUpType)powerUpTypes[Random.Range(0, powerUpTypes.Count)];
                
                Vector3 powerUpPositon = new Vector3(Random.Range(0.05f, 0.95f), Random.Range(0.05f, 0.95f), 10);

                GameObject powerUp = Instantiate(powerUpPrefab, Camera.main.ViewportToWorldPoint(powerUpPositon), Quaternion.identity) as GameObject;
                powerUp.SendMessage("InitPowerUp", selectedPowerUp);

                _powerUpSpawnTime = powerUpSpawnTime;
            }
        }
    }
}
