using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public TMP_Text uiText; // Assign your UI Text component in the Inspector
    public float fadeDuration = 2f; // Duration of the fade in seconds

    void Start()
    {
        if (uiText != null)
        {
            Color textColor = uiText.color;
            textColor.a = 0f; // Set initial alpha to 0 (fully transparent)
            uiText.color = textColor;
            StartCoroutine(FadeInText());
        }
    }

    private IEnumerator FadeInText()
    {
        float elapsedTime = 0f;
        Color textColor = uiText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            textColor.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration); // Gradually increase alpha
            uiText.color = textColor;
            yield return null;
        }

        // Ensure the alpha is exactly 1 at the end
        textColor.a = 1f;
        uiText.color = textColor;
    }
}
