
using UnityEngine;
using UnityEngine.UI;


public class ChoiceDialog : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text messageText;
    public Button YesButton;
    public Button NoButton;
    public string sceneToLoad;
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
                OnYesClicked();
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

    private void OnYesClicked()
    {
        if (playerInventory != null)
        {
            if (playerInventory.HasKey(doorKeyID))
            {
                GameManager.instance.EnterDoor();
                DoorSound.Play();
            }
            else if (playerInventory.HasAnyKey()) 
            {
                
                messageText.text = "ฮั่นแน่ ผิดดอกนะจ๊ะ";
            }
            else
            {
                
                messageText.text = "อยากเข้าไปก็ไปหากุญแจมา";
            }
        }
        
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
