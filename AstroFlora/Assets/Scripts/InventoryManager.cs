using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton instance

    public List<GameObject> inventory = new List<GameObject>(); // List to store collected flowers

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

    public void AddToInventory(GameObject collectedFlower)
    {
        // Add the collected flower to the inventory
        inventory.Add(collectedFlower);

        // Debug log to check if the flower is being added to the inventory
        Debug.Log("Added to inventory: " + collectedFlower.name);

        // Notify the FlowerCollection script to update the UI
        flowerCollection.UpdateUI();
    }

    // You can add more methods for managing the inventory, such as displaying it, using items, etc.
}