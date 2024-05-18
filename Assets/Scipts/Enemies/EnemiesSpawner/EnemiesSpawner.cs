using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    // List of enemy prefabs to spawn
    public List<GameObject> Enemies;

    void Start()
    {
        // Loop through the list of enemy prefabs
        foreach (GameObject enemyPrefab in Enemies)
        {
            // Instantiate each enemy prefab at the spawner's position with no rotation
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
