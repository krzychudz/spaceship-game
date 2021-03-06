using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform transform;
    public float movementSpeed = 5.0f;
    public float shieldTime = 5.0f;
    public Animator animator;

    public GameObject bulletPrefab;

    public AudioSource audioSource;

    private float _shootCooldown;
    private float _shieldTime;
    private bool _hasShield = false;

    // Start is called before the first frame update
    void Start()
    {
        _shootCooldown = 0;
        _shieldTime = shieldTime;
    }

    // Update is called once per frame
    void Update()
    {
        RotateToMouse();
        PerformShoot();
        CheckShieldState();
    }

    void FixedUpdate()
    {
        PerformMovement();
    }

    public void ApplyShield()
    {
        animator.SetBool("hasShield", true);
        _hasShield = true;
    }

    private void CheckShieldState()
    {
        if (_hasShield)
        {
            _shieldTime -= Time.deltaTime;
            if (_shieldTime < 0)
            {
                _shieldTime = shieldTime;
                _hasShield = false;
                animator.SetBool("hasShield", false);
            }
        }
    }

    private void PerformMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY);

        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }

    private void RotateToMouse()
    {
        Vector2 positionOnScreen = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Input.mousePosition;

        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

    }

    private void PerformShoot()
    {
        _shootCooldown -= Time.deltaTime;

        if (Input.GetMouseButton(0) && _shootCooldown <= 0)
        {
            Vector2 positionOnScreen = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 mouseOnScreen = (Vector2)Input.mousePosition;
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            Vector2 shootDir = mouseOnScreen - positionOnScreen;

            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0f, 0f, angle))) as GameObject;
            bullet.SendMessage("MoveToDirection", shootDir.normalized);

            _shootCooldown = GameManager.playerShootCooldown;

            audioSource.Play();
        }
          
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyAI enemyAI = col.gameObject.GetComponent<EnemyAI>();
            enemyAI.DestroyEnemy();
            if (!_hasShield)
            {
                GameManager.lives = GameManager.lives - 1;
            }
        }
    }
}
