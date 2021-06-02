using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    private float _spawnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        _spawnCooldown = GameManager.enemySpawnCooldown + Random.Range(-2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        _spawnCooldown -= Time.deltaTime;
        if (_spawnCooldown <= 0)
        {
            Instantiate(enemyPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            _spawnCooldown = GameManager.enemySpawnCooldown;
        }
    }
}
