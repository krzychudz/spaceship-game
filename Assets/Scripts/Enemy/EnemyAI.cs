using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    private Rigidbody2D rb;
    private Transform enemyTransform;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTransform = GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        Vector2 playerPosition = Camera.main.WorldToScreenPoint(playerTransform.position);
        Vector2 enemyPositon = Camera.main.WorldToScreenPoint(enemyTransform.position);

        Vector2 movementDir = (playerPosition - enemyPositon).normalized;
        rb.velocity = new Vector2(movementDir.x * movementSpeed, movementDir.y * movementSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
