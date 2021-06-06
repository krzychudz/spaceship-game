using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private PowerUpType powerUpType;
    public SpriteRenderer spriteRenderer;

    public Sprite healthPackSprite;
    public Sprite slowDownSprite;
    public Sprite explosionSprite;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitPowerUp(PowerUpType type)
    {
        powerUpType = type;
        spriteRenderer = GetComponent<SpriteRenderer>();

        switch (powerUpType)
        {
            case PowerUpType.Health:
                spriteRenderer.sprite = healthPackSprite;
                break;
            case PowerUpType.Explosion:
                spriteRenderer.sprite = explosionSprite;
                break;
            case PowerUpType.EnemySlowDown:
                spriteRenderer.sprite = slowDownSprite;
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PowerUpManager.isPowerUpSpawned = false;
            Destroy(gameObject);

            switch (powerUpType)
            {
                case PowerUpType.Health:
                    GameManager.lives++;
                    break;
                case PowerUpType.Explosion:
                    ClearEnemies();
                    break;
                case PowerUpType.EnemySlowDown:
                    break;
                default:
                    break;
            }
        }
    }

    private void ClearEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameManager.score += 50;
            Destroy(enemy);
        }
    }
}
