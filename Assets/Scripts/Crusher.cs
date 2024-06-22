using System.Collections;
using UnityEngine;

public class CrusherAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float triggerRange = 5.0f;
    public float moveDownSpeed = 10.0f;  // Faster speed for moving down
    public float moveUpSpeed = 2.0f;     // Slower speed for moving up
    public float delayAtBottom = 1.0f;
    [SerializeField] private Transform bottomPosition;
    private Vector3 originalPosition;
    private bool isCrushing = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        //Debug.Log($"{gameObject.name} distance to player: {distanceToPlayer}");

        if (distanceToPlayer <= triggerRange && !isCrushing)
        {
            Debug.Log($"{gameObject.name} is triggered");

            StartCoroutine(CrushCycle());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the drill bot if it hits any obstacle


        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with player");
            // Damage the player
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(3);

            
        }
    }

    private IEnumerator CrushCycle()
    {
        isCrushing = true;
        Debug.Log($"{gameObject.name} starting crush cycle");

        // Move down quickly
        while (Vector3.Distance(transform.position, bottomPosition.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, bottomPosition.position, moveDownSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = bottomPosition.position;

        // Wait at the bottom
        yield return new WaitForSeconds(delayAtBottom);

        // Move up slowly
        while (Vector3.Distance(transform.position, originalPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveUpSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = originalPosition;
        Debug.Log($"{gameObject.name} finished crush cycle");

        isCrushing = false;
    }
}