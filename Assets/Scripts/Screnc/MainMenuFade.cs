using UnityEngine;

public class MainMenuFade : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float fadeDuration = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        StartCoroutine(FadeIn());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float timeElapses = 0f;

        while(timeElapses < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f,1f,timeElapses / fadeDuration);
            timeElapses += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}
