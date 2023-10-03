using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton instance

    private List<GameObject> inventory = new List<GameObject>(); // List to store collected flowers

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
    }

    public void AddToInventory(GameObject collectedFlower)
    {
        // Add the collected flower to the inventory
        inventory.Add(collectedFlower);

        // You can update the UI to display the collected flowers in the player's inventory here
    }

    // You can add more methods for managing the inventory, such as displaying it, using items, etc.
}