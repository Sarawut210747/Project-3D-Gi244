using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float playTime; 
    public int collectedGems; 
    public Text timeText; 
    public Text gemText;  
    public Text summaryText; 
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // เก็บเวลาที่เล่น
        playTime += Time.deltaTime;
    }

    public void AddGem()
    {
        collectedGems++; 
    }

   
    public void EnterDoor()
    {
       
        string minutes = ((int)(playTime / 60)).ToString();
        string seconds = ((int)(playTime % 60)).ToString("00");

        
        SceneManager.LoadScene("Score");

       
        PlayerPrefs.SetInt("CollectedGems", collectedGems);
        PlayerPrefs.SetString("PlayTime", minutes + ":" + seconds); 
    }
}
