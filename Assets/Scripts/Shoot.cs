using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform leftShootPoint; // The point from which the projectile will be instantiated when facing left
    public Transform rightShootPoint; // The point from which the projectile will be instantiated when facing right
    public float shootCooldown = 0.5f; // Cooldown between shots
    public int maxShots = 3; // Maximum number of shots in a short window
    private float shootTimer;
    private int shotsFired;

    private SpriteRenderer sr; // Reference to the SpriteRenderer of the player

    void Start()
    {
        // Assuming this script is attached to the same GameObject as PlayerController
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        // Check if the shoot button (e.g., Fire1) is pressed
        if (Input.GetButtonDown("Fire1") && shotsFired < maxShots)
        {
            Shoot();
            shotsFired++;
        }

        // Reset the shots fired count after the cooldown period
        if (shootTimer >= shootCooldown)
        {
            shootTimer = 0f;
            shotsFired = 0;
        }
    }

    void Shoot()
    {
        // Determine the shoot point based on player facing direction
        Transform shootPoint = sr.flipX ? leftShootPoint : rightShootPoint;

        // Instantiate the projectile at the determined shoot point
        GameObject projectileInstance = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        // Set the projectile's direction
        Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            Vector2 direction = sr.flipX ? Vector2.left : Vector2.right;
            projectileScript.SetDirection(direction);
        }
    }
}
