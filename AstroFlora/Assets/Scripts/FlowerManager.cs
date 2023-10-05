using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    public static FlowerManager Instance;

    public List<Sprite> flowerSprites;  // List of flower sprites
    public List<GameObject> flowerPrefabs;  // List of corresponding flower prefabs

    private Dictionary<Sprite, GameObject> spriteToPrefab;  // Dictionary to map sprite to prefab

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one instance of FlowerManager
        }

        // Initialize the dictionary
        spriteToPrefab = new Dictionary<Sprite, GameObject>();

        // Fill the dictionary with sprite-to-prefab mappings
        for (int i = 0; i < flowerSprites.Count; i++)
        {
            if (i < flowerPrefabs.Count)
            {
                spriteToPrefab.Add(flowerSprites[i], flowerPrefabs[i]);
            }
        }
    }

    // Get the flower prefab for a given sprite
    public GameObject GetFlowerPrefabForSprite(Sprite sprite)
    {
        if (spriteToPrefab.ContainsKey(sprite))
        {
            return spriteToPrefab[sprite];
        }
        return null;
    }
}