using UnityEngine;
using UnityEngine.InputSystem;

public class CameraModeController : MonoBehaviour
{
    public LookHighlighter lookHighlighter;

    public bool cameraMode = false;

    void Start()
    {
        SetCameraMode(false);
    }

    void Update()
    {
        // Toggle camera mode with C
        if (Keyboard.current.cKey.wasPressedThisFrame)
            SetCameraMode(!cameraMode);

        if (!cameraMode) return;

        // Take photo with left click
        if (Mouse.current.leftButton.wasPressedThisFrame)
            TakePhoto();

        // Escape closes camera mode (optional)
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            SetCameraMode(false);
    }

    void SetCameraMode(bool on)
    {
        cameraMode = on;

        // Enable highlight only in camera mode
        if (lookHighlighter != null)
            lookHighlighter.enabled = on;

        // Update camera overlay UI
        if (UIManagerSimple.I != null)
            UIManagerSimple.I.SetCameraUI(on);

        // When turning OFF camera, reset everything
        if (!on)
        {
            if (lookHighlighter != null)
                lookHighlighter.ClearHighlight();
        }
    }

    void TakePhoto()
    {
        PhotoObject target = lookHighlighter.GetCurrentPhotoObject();

        // If you are not aiming at a PhotoObject, do nothing
        if (target == null) return;

        // Show photo result in the center of the screen
        if (UIManagerSimple.I != null)
            UIManagerSimple.I.ShowPhotoResult(target);
    }
}