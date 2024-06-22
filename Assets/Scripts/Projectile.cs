using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    private Vector2 direction;

    void Start()
    {
        // Default direction to right
        direction = Vector2.right;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
        Debug.Log("Projectile direction set to: " + direction);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile collides with an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Damage the enemy (assuming the enemy has a method to take damage)
            // collision.GetComponent<Enemy>().TakeDamage(damage);

            // Destroy the projectile
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            // Destroy the projectile if it hits the ground
            Destroy(gameObject);
        }
    }
}
