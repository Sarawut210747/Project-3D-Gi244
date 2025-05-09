using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditscroll : MonoBehaviour
{
    public float scrollSpeed = 50f;
    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}
