using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text messageText;
    public Button YesButton;
    private bool isPlayerNearby = false;
    private HealthManager playerHealth;

    void Start()
    {
        dialogPanel.SetActive(false);
        YesButton.onClick.AddListener(OnYesClicked);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            ShowDialog();
        }
    }

    private void ShowDialog()
    {
        dialogPanel.SetActive(true);
        messageText.text = "กดแล้วก็ตายนะ";
    }

    private void OnYesClicked()
    {
       if (playerHealth != null)
        {
            playerHealth.LoseLife(); // เรียกให้ผู้เล่นตาย
            Debug.Log("dawd");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            playerHealth = other.GetComponent<HealthManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            playerHealth = null;
            dialogPanel.SetActive(false);
        }
    }
}
