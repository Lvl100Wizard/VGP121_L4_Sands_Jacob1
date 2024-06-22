using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        Life,
        Health
    }

    [SerializeField] private PickupType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController pc = collision.GetComponent<PlayerController>();

            switch (type)
            {
                case PickupType.Life:
                    pc.lives++;
                    Debug.Log(pc.lives);
                    break;
                case PickupType.Health:
                    Debug.Log("I should be changing health");
                    break;

            }

            Destroy(gameObject);
        }
    }
}