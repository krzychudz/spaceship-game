using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform transform;
    public float movementSpeed = 5.0f;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PerformMovement();
        RotateToMouse();
        PerformShoot();
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
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 positionOnScreen = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 mouseOnScreen = (Vector2)Input.mousePosition;

            Vector2 shootDir = mouseOnScreen - positionOnScreen;

            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
            bullet.SendMessage("MoveToDirection", shootDir.normalized);
        }
          
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
