using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnCooldown = 5.0f;

    private float _spawnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        _spawnCooldown = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        _spawnCooldown -= Time.deltaTime;
        if (_spawnCooldown <= 0)
        {
            Instantiate(enemyPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            _spawnCooldown = spawnCooldown;
        }
    }
}
