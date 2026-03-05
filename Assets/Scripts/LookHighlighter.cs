using UnityEngine;

// This script raycasts from the camera forward.
// If it hits an object that has Highlightable, it highlights it.
// We also keep track of PhotoObject on the same object, so camera mode can "take photo".
public class LookHighlighter : MonoBehaviour
{
    public Camera playerCamera;
    public float detectionDistance = 10f;

    private Highlightable currentHighlight;
    private PhotoObject currentPhotoObject;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, detectionDistance))
        {
            // We expect Highlightable and PhotoObject to be on the same object
            // (or you can put them on parent/child later, but keep it simple now)
            Highlightable h = hit.collider.GetComponent<Highlightable>();
            PhotoObject p = hit.collider.GetComponent<PhotoObject>();

            if (h != null)
            {
                SetCurrent(h, p);
                return;
            }
        }

        // If raycast didn't hit a highlightable object, clear state
        ClearHighlight();
    }

    // Sets new current object (if different)
    void SetCurrent(Highlightable newHighlight, PhotoObject newPhotoObject)
    {
        if (currentHighlight == newHighlight) return;

        ClearHighlight();

        currentHighlight = newHighlight;
        currentPhotoObject = newPhotoObject;

        currentHighlight.SetHighlighted(true);
    }

    // Called by CameraModeController when we exit camera mode
    public void ClearHighlight()
    {
        if (currentHighlight != null)
            currentHighlight.SetHighlighted(false);

        currentHighlight = null;
        currentPhotoObject = null;
    }

    // CameraModeController calls this to know what we're looking at
    public PhotoObject GetCurrentPhotoObject()
    {
        return currentPhotoObject;
    }
}