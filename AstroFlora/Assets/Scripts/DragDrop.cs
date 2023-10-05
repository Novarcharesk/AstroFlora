using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Sprite draggedFlowerPrefab;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        draggedFlowerPrefab = GetComponent<Image>().sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the UI element with the mouse/finger
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if the UI element was dropped on a planet
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && (hit.collider.CompareTag("Mars") || hit.collider.CompareTag("Jupiter")))
        {
            // Get the planet's tag
            string planetTag = hit.collider.tag;

            // Spawn the matching flower prefab at a vacant spawner
            FlowerSpawner.Instance.SpawnFlowerForPlanet(planetTag, draggedFlowerPrefab);
        }
    }
}