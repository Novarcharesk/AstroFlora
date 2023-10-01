using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject[] flowerPrefabs; // Array to hold different flower prefabs
    public Transform[] spawners; // Array of spawner Transforms on the planet

    public float initialSpawnDelay = 2f; // Initial delay before the first flower spawns
    public float maxSpawnInterval = 10f; // Maximum time interval between flower spawns
    public float spawnIntervalDecreaseRate = 0.1f; // Rate at which spawn interval decreases

    private float currentSpawnInterval; // Current time interval between spawns

    private int spawnerIndex; // Index to keep track of the selected spawner

    private void Start()
    {
        // Initialize variables and setup logic here
        currentSpawnInterval = maxSpawnInterval;
        spawnerIndex = 0;

        // Start spawning flowers
        StartCoroutine(SpawnFlowers());
    }

    private IEnumerator SpawnFlowers()
    {
        // Wait for the initial spawn delay
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            // Get the current spawner
            Transform selectedSpawner = spawners[spawnerIndex];

            // Try to spawn a flower if the spawner is available
            if (selectedSpawner.childCount == 0)
            {
                // Choose a random flower prefab from the array
                int randomFlowerIndex = Random.Range(0, flowerPrefabs.Length);
                GameObject selectedFlowerPrefab = flowerPrefabs[randomFlowerIndex];

                // Instantiate the selected flower prefab at the selected spawner's position
                Instantiate(selectedFlowerPrefab, selectedSpawner.position, Quaternion.identity);

                // Move to the next spawner
                spawnerIndex = (spawnerIndex + 1) % spawners.Length;
            }

            // Decrease the current spawn interval to increase frequency
            currentSpawnInterval = Mathf.Max(maxSpawnInterval, currentSpawnInterval - spawnIntervalDecreaseRate);

            // Wait for the current spawn interval before spawning the next flower
            yield return new WaitForSeconds(currentSpawnInterval);
        }
    }
}