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
    private bool[] spawnerOccupied; // Array to track spawner occupancy

    public static FlowerSpawner Instance; // Singleton instance

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one instance of FlowerSpawner
        }
    }

    private void Start()
    {
        // Initialize variables and setup logic here
        currentSpawnInterval = maxSpawnInterval;
        spawnerIndex = 0;
        spawnerOccupied = new bool[spawners.Length];

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
            if (!spawnerOccupied[spawnerIndex])
            {
                // Choose a random flower prefab from the array
                int randomFlowerIndex = Random.Range(0, flowerPrefabs.Length);
                GameObject selectedFlowerPrefab = flowerPrefabs[randomFlowerIndex];

                // Instantiate the selected flower prefab at the selected spawner's position
                GameObject selectedFlower = Instantiate(selectedFlowerPrefab, selectedSpawner.position, Quaternion.identity);

                // Set the flower's initial planet based on the parent's tag
                selectedFlower.GetComponent<Flower>().currentPlanet = selectedSpawner.parent.tag;

                // Mark the spawner as occupied
                spawnerOccupied[spawnerIndex] = true;
            }

            // Decrease the current spawn interval to increase frequency
            currentSpawnInterval = Mathf.Max(maxSpawnInterval, currentSpawnInterval - spawnIntervalDecreaseRate);

            // Wait for the current spawn interval before spawning the next flower
            yield return new WaitForSeconds(currentSpawnInterval);

            // Move to the next spawner
            spawnerIndex = (spawnerIndex + 1) % spawners.Length;
        }
    }

    // Add the method to spawn a flower for a specific planet
    public void SpawnFlowerForPlanet(string planetTag, Sprite flowerSprite)
    {
        // Find a vacant spawner for the given planet
        int spawnerIndex = -1;
        for (int i = 0; i < spawners.Length; i++)
        {
            if (spawners[i].parent.CompareTag(planetTag) && !spawnerOccupied[i])
            {
                spawnerIndex = i;
                break;
            }
        }

        // Spawn the flower if a vacant spawner was found
        if (spawnerIndex != -1)
        {
            GameObject selectedFlowerPrefab = FlowerManager.Instance.GetFlowerPrefabForSprite(flowerSprite);

            if (selectedFlowerPrefab != null)
            {
                Transform selectedSpawner = spawners[spawnerIndex];
                GameObject selectedFlower = Instantiate(selectedFlowerPrefab, selectedSpawner.position, Quaternion.identity);
                selectedFlower.GetComponent<Flower>().currentPlanet = planetTag;
                spawnerOccupied[spawnerIndex] = true;
            }
        }
    }
}