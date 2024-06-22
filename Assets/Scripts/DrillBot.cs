using UnityEngine;

public class DrillBot : MonoBehaviour

{
    public float speed = 2f;
    public Vector2 direction = Vector2.up; // Default to moving up
    private Rigidbody2D rb;
    public SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity = direction * speed;
        if (direction.y < 0)
        { 
            sr.flipY = true; 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the drill bot if it hits any obstacle
        

            if (collision.gameObject.CompareTag("Player"))
            {
            Debug.Log("Collision with player");
                // Damage the player
                collision.gameObject.GetComponent<PlayerController>().TakeDamage(1);
            
                Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        // Destroy the drill bot if it goes off-screen
        Destroy(gameObject);
    }
}
