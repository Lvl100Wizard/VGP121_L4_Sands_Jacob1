using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillBotSpawner : MonoBehaviour
{
    public GameObject drillBotPrefab;
    public float spawnInterval = 2f;
    public Vector2 direction = Vector2.down; // Default to spawning down-moving drill bots

    private void Start()
    {
        InvokeRepeating("SpawnDrillBot", 0f, spawnInterval);
    }

    void SpawnDrillBot()
    {
        GameObject drillBot = Instantiate(drillBotPrefab, transform.position, Quaternion.identity);
        drillBot.GetComponent<DrillBot>().direction = direction;
    }
}

