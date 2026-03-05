using TMPro;
using UnityEngine;

// Handles prototype UI:
// - Camera overlay (black mask with viewfinder)
// - Photo result popup in the center
public class UIManagerSimple : MonoBehaviour
{
    public static UIManagerSimple I { get; private set; }

    [Header("Camera UI")]
    public GameObject cameraOverlay;      // CameraOverlay gameobject

    [Header("Photo Result UI")]
    public GameObject photoResultPanel;   // PhotoResultPanel gameobject
    public TMP_Text titleText;            // English word
    public TMP_Text translationText;      // Turkish word
    public TMP_Text exampleText;          // examples

    void Awake()
    {
        I = this;
    }

    // Called when camera mode toggles ON/OFF
    public void SetCameraUI(bool isOn)
    {
        if (cameraOverlay != null)
            cameraOverlay.SetActive(isOn);

        // When camera closes, clear the photo result too
        if (!isOn)
            HidePhotoResult();
    }

    public void ShowPhotoResult(PhotoObject data)
    {
        if (data == null) return;

        if (titleText != null) titleText.text = data.wordEnglish;
        if (translationText != null) translationText.text = data.wordTurkish;

        if (exampleText != null)
            exampleText.text = $"{data.exampleEnglish}\n{data.exampleTurkish}";

        if (photoResultPanel != null)
            photoResultPanel.SetActive(true);
    }

    public void HidePhotoResult()
    {
        if (photoResultPanel != null)
            photoResultPanel.SetActive(false);
    }
}