using UnityEngine;

// This script stores the vocabulary data for one photographable object.
public class PhotoObject : MonoBehaviour
{
    [Header("Main Words")]
    public string wordEnglish = "Cat";
    public string wordTurkish = "Kedi";

    [Header("Text shown immediately after taking photo")]
    [TextArea]
    public string photoDisplayText = "Cat";

    [Header("Example Sentences")]
    [TextArea] public string exampleEnglish = "Cat loves sleeping.";
    [TextArea] public string exampleTurkish = "Kedi uyumayı sever.";
}
