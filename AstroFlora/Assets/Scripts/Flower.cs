using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
    public float timeToDespawn = 10.0f; // Time in seconds before the flower despawns
    public Sprite inventoryIcon;
    public bool flowerForJupiter = false;

    private GameObject destinationPlanet; // Reference to the destination planet for this flower

    // Variable to track whether the flower has been collected
    private bool isCollected = false;

    private float despawnTimer; // Timer to track despawn time

    private void Start()
    {
        // Initialize the despawn timer
        despawnTimer = timeToDespawn;

        // Assign a random destination planet when the flower spawns
        AssignRandomDestinationPlanet();
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
                    // Call the Collect method
                    Collect();
                }
            }
        }
    }

    private void AssignRandomDestinationPlanet()
    {
        // Get a reference to the FlowerCollection script
        FlowerCollection flowerCollection = FindObjectOfType<FlowerCollection>();

        if (flowerCollection != null && flowerCollection.destinationPlanets != null && flowerCollection.destinationPlanets.Length > 0)
        {
            // Randomly select a destination planet from the FlowerCollection script
            int randomIndex = Random.Range(0, flowerCollection.destinationPlanets.Length);
            destinationPlanet = flowerCollection.destinationPlanets[randomIndex];

            // Set the destination planet for this flower
            SetDestinationPlanet(destinationPlanet);
        }
    }

    public void SetDestinationPlanet(GameObject destinationPlanet)
    {
        // Implement logic to set the destination planet for this flower
        // You can use this method to set the flower's destination planet.
        // This might involve changing the flower's appearance, color, or some other indication.
    }

    public void Collect()
    {
        // Handle the collection of the flower by the player
        if (!isCollected)
        {
            isCollected = true;

            // Deactivate the flower
            gameObject.SetActive(false);

            // Add the collected flower to the player's inventory
            InventoryManager.Instance.AddToInventory(gameObject);

            // Debug log to check if the flower is being collected
            Debug.Log("Flower collected: " + gameObject.name);

            // You may need to adjust other behaviors related to flower collection
        }
    }

    private void Despawn()
    {
        // Handle despawning behavior here (e.g., destroy the flower object)
        Destroy(gameObject);
    }
}