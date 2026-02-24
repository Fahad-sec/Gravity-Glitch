using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public void addScore()
    {
        playerScore++;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public GameObject gameOverScreen;
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void restartGame()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
