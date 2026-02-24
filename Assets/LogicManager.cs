using UnityEngine;
using TMPro;
public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public void addScore()
    {
        playerScore++;
        scoreText.text = "Score: " +playerScore.ToString();
    }
}
