using TMPro;
using UnityEngine;

// Handles prototype UI:
// - Camera overlay
// - Simple centered text after taking a photo
public class UIManagerSimple : MonoBehaviour
{
    public static UIManagerSimple I { get; private set; }

    [Header("Camera UI")]
    public GameObject cameraOverlay;

    [Header("Photo Result UI")]
    public GameObject photoResultPanel;
    public TMP_Text titleText;

    void Awake()
    {
        I = this;
    }

    // Turns camera overlay on/off
    public void SetCameraUI(bool isOn)
    {
        if (cameraOverlay != null)
            cameraOverlay.SetActive(isOn);

        // If camera closes, also hide the photo result
        if (!isOn)
            HidePhotoResult();
    }

    // Shows one custom text in the center of the screen
    public void ShowPhotoResult(PhotoObject data)
    {
        if (data == null) return;

        if (titleText != null)
            titleText.text = data.photoDisplayText;

        if (photoResultPanel != null)
            photoResultPanel.SetActive(true);
    }

    public void HidePhotoResult()
    {
        if (photoResultPanel != null)
            photoResultPanel.SetActive(false);
    }
}