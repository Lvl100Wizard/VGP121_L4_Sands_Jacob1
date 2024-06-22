using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int currentHealth;
    public int maxHealth = 5;


    //a very cool way to control player lives :)
    private int _lives;
    public int lives
    {
        get => _lives;
        set
        {
            if (value <= 0) GameOver();
            if (value < _lives) Respawn();
            if (value > maxLives) value = maxLives;
            _lives = value;

            Debug.Log($"Lives have been set to {_lives}");
            //broadcast can happen here
        }
    }

    [SerializeField] private int maxLives = 5;




    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        lives = maxLives;
        currentHealth = maxHealth;

    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        } 

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
        }

        anim.SetFloat("speed", Mathf.Abs(move));

        anim.SetBool("isGrounded", isGrounded);

        if (move != 0) sr.flipX = (move < 0);



    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    void Die()
    {

        Debug.Log("Death should happen");
        // Add death logic
    }




    private void GameOver()
    {
        Debug.Log("GameOver goes here");
    }

    private void Respawn()
    {
        Debug.Log("Respawn goes here");
    }


}
