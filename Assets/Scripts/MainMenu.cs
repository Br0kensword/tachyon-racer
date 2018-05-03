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
        Cursor.visible = false;
    }

    public void EndGame (float distanceTraveled)
    {
        int score = (int)(distanceTraveled * 10f);
        scoreLabel.text = "Score: " + score.ToString();
        
        if(PlayerPrefs.HasKey("HighScore")){
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else{
            highScore = 0;
        }

        if (score > highScore)
        {
            highScore = score;
        }

        highScoreLabel.text = "High Score: " + highScore.ToString();
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
        gameObject.SetActive(true);
        Cursor.visible = true;
    }
}