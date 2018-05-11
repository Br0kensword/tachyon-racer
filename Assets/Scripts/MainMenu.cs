using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Player player;
    public Text scoreLabel, highScoreLabel;

    public GameObject BackgroundMusic;

    public Sprite muteImage, soundImage;
    private int highScore;

    private bool muted = false;

    public void StartGame()
    {
        player.StartGame();
        gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void Mute()
    {
        Image image = GameObject.FindGameObjectWithTag("muteButton").GetComponent<Image>();

        if (!muted)
        {
            BackgroundMusic.GetComponentInChildren<AudioSource>().enabled = false;
            muted = true;
            image.sprite = muteImage;
        }
        else
        {
            BackgroundMusic.GetComponentInChildren<AudioSource>().enabled = true;
            muted = false;
            image.sprite = soundImage;
        }
    }

    public void tbLink()
    {       
        Application.OpenURL("http://www.tuxedobirds.com");
    }

    public void musicLink()
    {
        Application.OpenURL("http://freemusicarchive.org/music/Ask%20Again/");
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