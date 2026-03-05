using UnityEngine;

// This script marks an object as "photographable"
// and stores the word info that will be shown after taking a photo.
public class PhotoObject : MonoBehaviour
{
    [Header("Word Info")]
    public string wordEnglish = "Cat";
    public string wordTurkish = "Kedi";

    [TextArea] public string exampleEnglish = "Cat loves sleeping.";
    [TextArea] public string exampleTurkish = "Kedi uyumayı sever.";
}
