using System.Collections;
using UnityEngine;

public class FaedInEffect : MonoBehaviour
{
    public CanvasGroup fadePanel;
    public float fadeDuration = 2f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadePanel.alpha = 1 - (elapsedTime / fadeDuration);
            yield return null;
        }
        fadePanel.alpha = 0;
        fadePanel.gameObject.SetActive(false);
    }
}
