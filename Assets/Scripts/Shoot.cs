using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint; // The point from which the projectile will be instantiated
    public float shootCooldown = 0.5f; // Cooldown between shots
    public int maxShots = 3; // Maximum number of shots in a short window
    private float shootTimer;
    private int shotsFired;

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
        // Instantiate the projectile at the shoot point
        Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
    }
}