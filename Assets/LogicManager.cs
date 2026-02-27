using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject MainMenu;
    public GameObject gameOverScreen;
    public static bool isRestarting = false;
    public ScreenShake screenShake;


    public  void PlayGame()
    {
        isRestarting
        = true;
        MainMenu.SetActive(false);
        Time.timeScale = 1f;    
    }
    void Start()

    {
        if (!isRestarting)
        {
            MainMenu.SetActive(true);
            Time.timeScale = 0F;

        }else
        {
            MainMenu.SetActive (false);
            Time.timeScale = 1f;
        }
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore+= scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void GameOver()
    {
        StartCoroutine(screenShake.Shake(0.3f, 0.5f));
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f; 
        CheckingHighScore();
    }

    public void RestartGame()

    {
        isRestarting = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void CheckingHighScore() { 
    
        if (playerScore> PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = "New Best: " + playerScore.ToString();
        }
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
            Debug.Log("Exiting Game...");
        }
    }

}
