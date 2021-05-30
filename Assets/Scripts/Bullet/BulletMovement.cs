using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed = 5.0f;
    public int timeToLiveSec = 5;

    private Rigidbody2D rb;
    private Vector2 moveDirection = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToLiveSec);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    void MoveToDirection(Vector2 direction)
    {
        moveDirection = direction;
    }
}
