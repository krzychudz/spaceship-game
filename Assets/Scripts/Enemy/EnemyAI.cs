using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float movementSpeed = 3.5f;
    public float slowDownTime = 0.0f;

    public GameObject destroyedPrefab;

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
        if (slowDownTime >= 0)
        {
            slowDownTime -= Time.deltaTime;
        } else
        {
            movementSpeed = 3.5f;
        }

        AdjustRotationRelativeToPlayer();
    }

    void FixedUpdate()
    {
        Vector2 playerPosition = Camera.main.WorldToScreenPoint(playerTransform.position);
        Vector2 enemyPositon = Camera.main.WorldToScreenPoint(enemyTransform.position);

        Vector2 movementDir = (playerPosition - enemyPositon).normalized;
        rb.velocity = new Vector2(movementDir.x * movementSpeed, movementDir.y * movementSpeed);
    }

    void SlowDown()
    {
        slowDownTime = 2.5f;
        movementSpeed = 2.0f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            GameManager.score += 50;
            DestroyEnemy();
        }
    }

    private void AdjustRotationRelativeToPlayer()
    {
        Vector2 positionOnScreen = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 playerPositionOnScreen = Camera.main.WorldToScreenPoint(playerTransform.position);

        float angle = AngleBetweenTwoPoints(positionOnScreen, playerPositionOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void DestroyEnemy()
    {
        Instantiate(destroyedPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        Destroy(gameObject);
    }
}
