using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject destinationPlanetPrefab; // Reference to the destination planet prefab
    public float timeToDespawn = 10.0f; // Time in seconds before the flower despawns
    public GameObject planet; // Reference to the planet where this flower resides

    // Variable to track whether the flower has been collected
    private bool isCollected = false;

    private float despawnTimer; // Timer to track despawn time

    private void Start()
    {
        // Initialize the despawn timer
        despawnTimer = timeToDespawn;
    }

    private void Update()
    {
        // Check if the flower should be despawned based on the timer
        if (!isCollected)
        {
            despawnTimer -= Time.deltaTime;
            if (despawnTimer <= 0)
            {
                Despawn();
            }
        }

        // Debug log before raycasting
        Debug.Log("Checking for click...");

        // Check for mouse click
        if (!isCollected && Input.GetMouseButtonDown(0)) // Assuming left mouse button (0) is used for interaction
        {
            // Raycast from the mouse position to detect if the flower is clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // Debug log when the flower is clicked
                    Debug.Log("Flower clicked!");

                    // Call the Collect method
                    Collect();
                }
            }
        }
    }

    public void Collect()
    {
        // Handle the collection of the flower by the player
        if (!isCollected)
        {
            isCollected = true;

            // Deactivate or destroy the flower (you can choose which option to use)
            gameObject.SetActive(false); // Deactivate the flower

            // Add the collected flower to the player's inventory
            InventoryManager.Instance.AddToInventory(gameObject);

            // You may need to adjust other behaviors related to flower collection
        }
    }

    private void Despawn()
    {
        // Handle despawning behavior here (e.g., destroy the flower object)
        Destroy(gameObject);
    }
}