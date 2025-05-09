using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuUI;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    public void OpenMenu()
    {
        menuUI.SetActive(true);
        playerMovement.SetUIState(true); 
    }

    public void CloseMenu()
    {
        menuUI.SetActive(false);
        playerMovement.SetUIState(false); 
    }
}
