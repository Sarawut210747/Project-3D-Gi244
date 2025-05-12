using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
 public static HealthManager instance;

    public int maxLives = 3;
    private int currentLives;

    public Text livesText;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (PlayerPrefs.HasKey("CurrentLives"))
        {
            currentLives = PlayerPrefs.GetInt("CurrentLives"); 
            
        }
        else
        {
            currentLives = maxLives; 
        }
    }

    void Start()
    {
        UpdateLivesUI();
    }

    public void LoseLife()
    {
        currentLives--; // ลดชีวิตลง 1
        PlayerPrefs.SetInt("CurrentLives", currentLives); // บันทึกค่าชีวิตไว้
        PlayerPrefs.Save();

        UpdateLivesUI();

        if (currentLives <= 0)
        {
            PlayerPrefs.DeleteKey("CurrentLives"); // ลบค่าชีวิตเมื่อเกมโอเวอร์
            SceneManager.LoadScene("GameOver"); // ไปที่ซีน "Game Over"
        }
        else
        {
            RestartLevel(); // โหลดซีนใหม่แต่ไม่รีเซ็ตชีวิต
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "" + currentLives;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetLives()
    {
        currentLives = maxLives;
        PlayerPrefs.SetInt("CurrentLives", currentLives); // รีเซ็ตค่าชีวิตใน PlayerPrefs
        PlayerPrefs.Save();
        UpdateLivesUI();
    }
    public void RestartGame()
    {
    SceneManager.LoadScene("DemoMAP_version1");
    }
}
