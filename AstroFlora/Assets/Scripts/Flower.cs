using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject destinationPlanetPrefab; // Reference to the destination planet prefab
    public float maxSaturation = 1.0f;
    public float currentSaturation;
    private float despawnTimer;
    public float timeToDespawn = 10.0f; // Time in seconds before the flower despawns
    public GameObject planet; // Reference to the planet where this flower resides
    public GameObject[] flowerPrefabs; // Array to hold different flower prefabs


    // Reference to the UI slot where the flower should be placed when collected
    public Transform uiSlot;

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
        // Implement any flower-related behaviors here
        // For example, decrease saturation over time
        if (!isCollected)
        {
            DecreaseSaturation(Time.deltaTime);
            // Check if the flower has lost all saturation and should despawn
            if (currentSaturation <= 0)
            {
                Despawn();
            }
        }
    }

    public void DecreaseSaturation(float amount)
    {
        currentSaturation -= amount;
        // Update visual indicators here
    }

    public void Collect()
    {
        // Handle the collection of the flower by the player
        if (!isCollected)
        {
            isCollected = true;

            // Deactivate or destroy the flower (you can choose which option to use)
            gameObject.SetActive(false); // Deactivate the flower

            // Move the flower's visual representation to the UI slot
            Transform visualFlower = Instantiate(transform, uiSlot.position, UnityEngine.Quaternion.identity);
            visualFlower.SetParent(uiSlot);

            // You may need to adjust the position, scale, or other properties of the visualFlower
        }
    }

    private void Despawn()
    {
        // Handle despawning behavior here (e.g., destroy the flower object)
        Destroy(gameObject);
    }
}