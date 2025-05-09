using UnityEngine;
using UnityEngine.UI;

public class PaperInteraction : MonoBehaviour
{
     public GameObject paperUI; // ลาก UI ที่ใช้แสดงกระดาษมาใส่ใน Inspector
    private bool isPlayerNear = false; // เช็คว่าผู้เล่นอยู่ใกล้หรือไม่
    private bool isReading = false; // เช็คว่าผู้เล่นกำลังอ่านอยู่หรือไม่
     public GameObject messagePanel; 
    public Text messageText; 

    void Start()
    {
        paperUI.SetActive(false); // ซ่อน UI ตอนเริ่มเกม
        messagePanel.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F)) // กด F เมื่ออยู่ใกล้
        {
            TogglePaper();
        }
    }

    void TogglePaper()
    {
        isReading = !isReading; // สลับสถานะการอ่าน
        paperUI.SetActive(isReading); // แสดง/ซ่อน UI
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ตรวจสอบว่าผู้เล่นอยู่ในระยะ
        {
            isPlayerNear = true;
            messagePanel.SetActive(true);
            messageText.text = "กด F นะเพื่ออ่าน";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            messagePanel.SetActive(false); // ซ่อนข้อความแจ้งเตือนเมื่อเดินออก
            paperUI.SetActive(false); // ปิด UI กระดาษ
            isReading = false;
        }
    }
}
