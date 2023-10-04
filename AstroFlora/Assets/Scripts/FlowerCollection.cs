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
        collectedFlowers = InventoryManager.Instance.inventory;
        // Update the UI slots with the collected flower prefabs
        for (int i = 0; i < collectedFlowers.Count; i++)
        {
            // You can access the collectedFlowers[i] to display or manipulate it as needed in your UI.
            // You may need to modify your UI slot prefabs to accommodate the flower prefabs.
            //Vector3 iconPosition = flowerSlots[i].gameObject.transform.position;
            //Vector3 worldIconPosition = Camera.main.ScreenToWorldPoint(iconPosition);
            //Debug.Log("will spawn " + collectedFlowers[i] + " at " + worldIconPosition);
            //Instantiate(objectToInstantiateDebug, worldIconPosition, Quaternion.identity);
            inventoryImages[i].enabled = true;
            inventoryImages[i].sprite = collectedFlowers[i].GetComponent<Flower>().inventoryIcon;
        }
    }

    public void AddCollectedFlower(GameObject collectedFlowerPrefab, string flowerName)
    {
        collectedFlowerList.Add(new CollectedFlowerInfo { collectedFlowerPrefab = collectedFlowerPrefab, flowerName = flowerName });
    }
}