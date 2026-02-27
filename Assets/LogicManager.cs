using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject MainMenu;
    public GameObject gameOverScreen;
    public static bool isRestarting = false;
    public ScreenShake screenShake;
    public SpriteRenderer backgroundDisplay;
    public Sprite[] levelBackgrounds;
    public TextMeshProUGUI levelText;
    public int level = 1;
    public ObstacleSpawner spawner;



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
        ObstacleBehaviour.moveSpeed = 2f;
        spawner.spawnRate = 5f;
        spawner.heightOffset = 3f;
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore+= scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();

        if (playerScore >= level *10) {
            IncreaseDifficulty();
        }

    }

    void IncreaseDifficulty()
    {
        level++;
        if (levelText != null) levelText.text = "Level: " + level.ToString();
        if (levelBackgrounds != null && levelBackgrounds.Length> 0)
        {
            int bgIndex = (level -1) % levelBackgrounds.Length;
            backgroundDisplay.sprite = levelBackgrounds[bgIndex];
        }

        ObstacleBehaviour.moveSpeed += 0.5f;
        if (spawner !=null)
        {
            spawner.spawnRate = Mathf.Max(1f, spawner.spawnRate - 0.9f);
            spawner.heightOffset = Mathf.Max(1.0f, spawner.heightOffset - 0.2f);


        }
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
        ObstacleBehaviour.moveSpeed = 2f;
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
