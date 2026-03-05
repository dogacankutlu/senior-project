using UnityEngine;

public class LookHighlighter : MonoBehaviour
{
    // Reference to the camera that will shoot the ray
    public Camera playerCamera;

    // Maximum distance the player can detect objects
    public float detectionDistance = 10f;

    // Stores the currently highlighted object
    private Highlightable currentObject;

    void Update()
    {
        // Create a ray from the center of the camera
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        RaycastHit hit;

        // Check if the ray hits something
        if (Physics.Raycast(ray, out hit, detectionDistance))
        {
            // Try to find a Highlightable component on the object hit
            Highlightable highlightable = hit.collider.GetComponent<Highlightable>();

            if (highlightable != null)
            {
                // If we are looking at a new object
                if (currentObject != highlightable)
                {
                    ClearCurrentObject();

                    currentObject = highlightable;
                    currentObject.SetHighlighted(true);
                }

                return;
            }
        }

        // If nothing valid is hit, remove highlight
        ClearCurrentObject();
    }

    void ClearCurrentObject()
    {
        if (currentObject != null)
        {
            currentObject.SetHighlighted(false);
            currentObject = null;
        }
    }
}
