using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Player player;
    public Text scoreLabel, highScoreLabel;
    private int highScore;

    public void StartGame()
    {
        player.StartGame();
        gameObject.SetActive(false);
    }

    public void EndGame (float distanceTraveled)
    {
        int score = (int)(distanceTraveled * 10f);
        scoreLabel.text = "Score: " + score.ToString();
        

        if (score > highScore)
        {
            highScore = score;
        }

        highScoreLabel.text = "High Score: " + score.ToString();
        gameObject.SetActive(true);
    }
}