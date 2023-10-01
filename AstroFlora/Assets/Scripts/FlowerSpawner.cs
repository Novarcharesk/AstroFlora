using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject[] flowerPrefabs; // Array to hold different flower prefabs
    public Transform[] spawners; // Array of spawner Transforms on the planet

    public float initialSpawnDelay = 2f; // Initial delay before the first flower spawns
    public float spawnInterval = 5f; // Time interval between flower spawns
    public float minSpawnInterval = 1f; // Minimum time interval between spawns
    public float spawnIntervalDecreaseRate = 0.1f; // Rate at which spawn interval decreases

    private void Start()
    {
        // Initialize variables and setup logic here
        InvokeRepeating("SpawnFlower", initialSpawnDelay, spawnInterval);
    }

    private void SpawnFlower()
    {
        // Choose a random spawner from the array
        int randomSpawnerIndex = Random.Range(0, spawners.Length);
        Transform selectedSpawner = spawners[randomSpawnerIndex].transform;

        // Check if there's already a flower at this spawner
        if (selectedSpawner.childCount == 0)
        {
            // Choose a random flower prefab from the array
            int randomFlowerIndex = Random.Range(0, flowerPrefabs.Length);
            GameObject selectedFlowerPrefab = flowerPrefabs[randomFlowerIndex];

            // Instantiate the selected flower prefab at the selected spawner's position
            Instantiate(selectedFlowerPrefab, selectedSpawner.position, Quaternion.identity);

            // Decrease the spawn interval over time to increase frequency
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - spawnIntervalDecreaseRate);
        }
    }
}