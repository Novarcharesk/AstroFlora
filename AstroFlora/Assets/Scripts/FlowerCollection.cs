using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerCollection : MonoBehaviour
{
    [System.Serializable]
    public class CollectedFlowerInfo
    {
        public GameObject collectedFlowerPrefab;
        public string flowerName;
    }

    public RectTransform[] flowerSlots; // UI slots for displaying collected flowers
    private List<CollectedFlowerInfo> collectedFlowerList = new List<CollectedFlowerInfo>();
    private int currentSlot = 0; // Index of the current slot

    private List<GameObject> collectedFlowers = new List<GameObject>(); // List to store collected flower prefabs

    public GameObject[] destinationPlanets; // Array of destination planet GameObjects

    public Image[] inventoryImages;

    public void CollectFlower(int flowerIndex)
    {
        if (flowerIndex >= 0 && flowerIndex < collectedFlowerList.Count)
        {
            if (currentSlot < flowerSlots.Length)
            {
                // Instantiate the selected collected flower prefab
                GameObject collectedFlower = Instantiate(collectedFlowerList[flowerIndex].collectedFlowerPrefab, flowerSlots[currentSlot].position, Quaternion.identity);

                // Make the collected flower a child of the UI slot
                collectedFlower.transform.SetParent(flowerSlots[currentSlot]);

                // Store the reference to the collected flower prefab
                collectedFlowers.Add(collectedFlower);

                // Increment the current slot index
                currentSlot++;
            }
        }
    }

    public void UpdateUI()
    {
        // Debug log to check if the UI is being updated
        Debug.Log("UI updated");

        // Get the collected flowers from the InventoryManager
        collectedFlowers = InventoryManager.Instance.inventory;

        // Update the UI slots with the collected flower prefabs
        for (int i = 0; i < collectedFlowers.Count && i < flowerSlots.Length; i++)
        {
            // Enable the slot's image component
            Image slotImage = flowerSlots[i].GetComponentInChildren<Image>();
            slotImage.enabled = true;

            // Set the sprite of the slot's image to match the collected flower
            slotImage.sprite = collectedFlowers[i].GetComponent<Flower>().inventoryIcon;
        }
    }

    public void AddCollectedFlower(GameObject collectedFlowerPrefab, string flowerName)
    {
        collectedFlowerList.Add(new CollectedFlowerInfo { collectedFlowerPrefab = collectedFlowerPrefab, flowerName = flowerName });
    }
}