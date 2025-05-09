using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    public string sceneToLoad;
    public Button YesButton;
    void Start()
    {
        YesButton.onClick.AddListener(OnYesClicked);
    }
    private void OnYesClicked()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
