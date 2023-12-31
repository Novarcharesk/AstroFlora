using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private float interpSpeed = 2.0f;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private bool isMoving = false;

    private void Start()
    {
        // Set the default camera position and rotation
        defaultPosition = transform.localPosition;
        defaultRotation = transform.localRotation;

        // Debug log to indicate the player's position
        Debug.Log("Player is at the default position.");
    }

    private void Update()
    {
        // Check for mouse click to zoom in or out
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Mars"))
                {
                    // Set the target position and rotation for the Mars planet
                    SetTargetPositionAndRotation(new Vector3(7.59f, 0.98f, -7.58f), Quaternion.Euler(0, 48.911f, 0));
                }
                else if (hit.collider.CompareTag("Jupiter"))
                {
                    // Set the target position and rotation for the Jupiter planet
                    SetTargetPositionAndRotation(new Vector3(13.28f, 1.14f, -7.58f), Quaternion.Euler(7.428f, -46.232f, -2.173f));
                }
                // Add more conditions for other planets as needed
            }
        }
    }

    private void SetTargetPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        targetPosition = position;
        targetRotation = rotation;

        // Start the camera movement
        StartCoroutine(InterpolateCamera());
    }

    public void MoveToDefaultPosition()
    {
        SetTargetPositionAndRotation(defaultPosition, defaultRotation);
    }

    IEnumerator InterpolateCamera()
    {
        isMoving = true;

        float journeyLength = Vector3.Distance(transform.localPosition, targetPosition);

        float startTime = Time.time;
        while (Time.time - startTime < journeyLength / interpSpeed)
        {
            float distanceCovered = (Time.time - startTime) * interpSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            transform.localPosition = Vector3.Lerp(defaultPosition, targetPosition, fractionOfJourney);
            transform.localRotation = Quaternion.Slerp(defaultRotation, targetRotation, fractionOfJourney);

            yield return null;
        }

        // Ensure the camera reaches the exact target position and rotation
        transform.localPosition = targetPosition;
        transform.localRotation = targetRotation;

        isMoving = false;

        // Debug log to indicate the player's position
        if (targetPosition == defaultPosition)
        {
            Debug.Log("Player is at the default position.");
        }
        else if (targetPosition.x > 10)
        {
            Debug.Log("Player is at Jupiter");
        }
        else
        {
            Debug.Log("Player is at Mars");
        }
    }
}