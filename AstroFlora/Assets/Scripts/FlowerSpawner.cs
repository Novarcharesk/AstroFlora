using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject[] flowerPrefabs; // Array to hold different flower prefabs
    public Transform[] spawners; // Array of spawner Transforms on the planet

    // Other variables for spawn rate, timer, etc. (if needed)

    private void Start()
    {
        // Initialize any variables or setup logic here

        // Spawn the first flower with a delay (e.g., 2 seconds) after the game starts
        Invoke("SpawnFirstFlower", 2f);
    }

    private void Update()
    {
        // Implement any spawn-related logic (e.g., spawn rate) here
        // You can use Time.deltaTime to track time for spawning flowers
    }

    // Create a method to spawn the first flower
    // Create a method to spawn the first flower
    private void SpawnFirstFlower()
    {
        // Choose a random spawner from the array
        int randomSpawnerIndex = Random.Range(0, spawners.Length);
        Transform selectedSpawner = spawners[randomSpawnerIndex];

        // Choose a random flower prefab from the array
        int randomFlowerIndex = Random.Range(0, flowerPrefabs.Length);
        GameObject selectedFlowerPrefab = flowerPrefabs[randomFlowerIndex];

        // Instantiate the selected flower prefab at the selected spawner's position
        Instantiate(selectedFlowerPrefab, selectedSpawner.position, Quaternion.identity);
    }

    // Create a method to spawn a flower on a random spawner
    public void SpawnFlower()
    {
        // Choose a random spawner from the array
        int randomSpawnerIndex = Random.Range(0, spawners.Length);
        Transform selectedSpawner = spawners[randomSpawnerIndex].transform;

        // Choose a random flower prefab from the array
        int randomFlowerIndex = Random.Range(0, flowerPrefabs.Length);
        GameObject selectedFlowerPrefab = flowerPrefabs[randomFlowerIndex];

        // Instantiate the selected flower prefab at the selected spawner's position
        Instantiate(selectedFlowerPrefab, selectedSpawner.position, Quaternion.identity);
    }
}