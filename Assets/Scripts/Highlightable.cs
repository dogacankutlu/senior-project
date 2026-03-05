using UnityEngine;

public class Highlightable : MonoBehaviour
{
    // Reference to the object's renderer (used to change materials)
    public Renderer objectRenderer;

    // Material used when the object is NOT highlighted
    public Material normalMaterial;

    // Material used when the player looks at the object
    public Material highlightMaterial;

    void Awake()
    {
        // If the renderer is not assigned manually,
        // automatically find it on this object
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();
        }

        // When the game starts, ensure the object has the normal material
        if (normalMaterial != null)
        {
            objectRenderer.material = normalMaterial;
        }
    }

    // This function is called by another script when the player
    // starts or stops looking at the object
    public void SetHighlighted(bool state)
    {
        if (objectRenderer == null) return;

        // If state = true -> apply highlight material
        // If state = false -> revert to normal material
        objectRenderer.material = state ? highlightMaterial : normalMaterial;
    }
}