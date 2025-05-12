using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToNextSecne : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text messageText;
    public Button YesButton;
    public Button NoButton;
    public int doorKeyID; 
    private bool isPlayer = false;
    private PlayerInventory playerInventory;

     public AudioSource DoorSound;

    void Start()
    {
        dialogPanel.SetActive(false);
    }

    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.F))
        {
            ShowDialog();
        }
        if (dialogPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) 
            {
                SceneManager.LoadScene("EndCredit");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) 
            {
                OnNoClicked();
            }
        }
    }

    private void ShowDialog()
    {
        dialogPanel.SetActive(true);
        messageText.text = "เข้ามั้ย?";
    }

    private void OnNoClicked()
    {
        CloseDialog();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
            playerInventory = other.GetComponent<PlayerInventory>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = false;
            playerInventory = null;
        }
    }
    private void CloseDialog()
    {
        dialogPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
