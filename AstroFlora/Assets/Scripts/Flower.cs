using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject destinationPlanetPrefab; // Reference to the destination planet prefab
    public float timeToDespawn = 10.0f; // Time in seconds before the flower despawns
    public GameObject planet; // Reference to the planet where this flower resides

    // Variable to track whether the flower has been collected
    private bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize any necessary values here
    }

    // Update is called once per frame
    void Update()
    {
        // Implement any flower-related behaviors here (if needed)
        // You can add any custom behavior or effects here
    }

    public void Collect()
    {
        // Handle the collection of the flower by the player
        if (!isCollected)
        {
            isCollected = true;

            // Deactivate or destroy the flower (you can choose which option to use)
            gameObject.SetActive(false); // Deactivate the flower

            // You may need to adjust other behaviors related to flower collection
        }
    }

    private void Despawn()
    {
        // Handle despawning behavior here (e.g., destroy the flower object)
        Destroy(gameObject);
    }
}