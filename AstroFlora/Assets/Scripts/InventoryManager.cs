using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton instance

    public List<GameObject> inventory = new List<GameObject>(); // List to store collected flowers

    public FlowerSpawner flowerSpawner;

    private FlowerCollection flowerCollection; // Reference to the FlowerCollection script for UI updates

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one instance of InventoryManager
        }

        // Get a reference to the FlowerCollection script
        flowerCollection = GetComponent<FlowerCollection>();
    }

    // Add the PlayerIsAtPlanet function here

    public string PlayerIsAtPlanet()
    {
        // Get the camera's current position
        Vector3 cameraPosition = Camera.main.transform.position;

        // Check proximity to each planet's target position
        GameObject[] planets = GameObject.FindGameObjectsWithTag("PlanetTarget");

        foreach (GameObject planet in planets)
        {
            float distanceToPlanet = Vector3.Distance(cameraPosition, planet.transform.position);

            // Adjust the threshold as needed
            float proximityThreshold = 2.0f;

            if (distanceToPlanet <= proximityThreshold)
            {
                // The player is considered to be at the current planet
                return planet.tag;
            }
        }

        // If none of the planets are within proximity, return an empty string
        return "";
    }

    public void UseInventoryItem(int index)
    {
        string playerLocation = PlayerIsAtPlanet();

        // Modify the logic based on the player's location
        if (playerLocation == "Mars")
        {
            // Handle flower spawning for Mars
            // Example: Transform[] marsSpawners = flowerSpawner.GetSpawnersForPlanet("Mars");
        }
        else if (playerLocation == "Jupiter")
        {
            // Handle flower spawning for Jupiter
            // Example: Transform[] jupiterSpawners = flowerSpawner.GetSpawnersForPlanet("Jupiter");
        }
        // Add more conditions for other planets as needed

        RemoveFromInventory(inventory[index], index);
    }

    public void AddToInventory(GameObject collectedFlower)
    {
        // Add the collected flower to the inventory
        inventory.Add(collectedFlower);

        // Debug log to check if the flower is being added to the inventory
        Debug.Log("Added to inventory: " + collectedFlower.name);

        // Notify the FlowerCollection script to update the UI
        flowerCollection.UpdateUI();
    }

    public void RemoveFromInventory(GameObject collectedFlower, int index)
    {
        // Remove the collected flower from the inventory
        inventory.Remove(collectedFlower);

        // Notify the FlowerCollection script to update the UI and remove the flower from the display
        flowerCollection.RemoveViaIndex(index);
        flowerCollection.UpdateUI();
    }

    // ... Other methods ...
}