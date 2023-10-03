using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void CollectFlower(int flowerIndex)
    {
        Debug.Log("CollectFlower method called with index: " + flowerIndex);

        if (flowerIndex >= 0 && flowerIndex < collectedFlowerList.Count)
        {
            if (currentSlot < flowerSlots.Length)
            {
                Debug.Log("Creating collected flower at slot: " + currentSlot);

                // Instantiate the selected collected flower prefab
                GameObject collectedFlower = Instantiate(collectedFlowerList[flowerIndex].collectedFlowerPrefab, flowerSlots[currentSlot].position, Quaternion.identity);

                // Make the collected flower a child of the UI slot
                collectedFlower.transform.SetParent(flowerSlots[currentSlot]);

                // Optionally, you can adjust the scale or rotation of the collected flower if needed

                // Increment the current slot index
                currentSlot++;
            }
        }
    }

    public void AddCollectedFlower(GameObject collectedFlowerPrefab, string flowerName)
    {
        collectedFlowerList.Add(new CollectedFlowerInfo { collectedFlowerPrefab = collectedFlowerPrefab, flowerName = flowerName });
    }
}