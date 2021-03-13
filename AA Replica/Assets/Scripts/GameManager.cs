using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    public float gameTime;

    public static int livesLeft;
    public static List<int> scoreList = new List<int>();

    public Rotator rotator;
    public Spawner spawner;
    public Text timeText;
    public Text livesText;
    public Text nameText;
    public AudioSource theMusic;

    public Animator animator;

    private void Start()
    {
        gameTime = (Time.time + IntroManager.timer);
        livesText.text = "Lives Left: " + livesLeft;
        nameText.text = IntroManager.playerName;
        theMusic.enabled = IntroManager.musicOn;
    }
    private void Update()
    {
        timeText.text = "Time Left: " + (gameTime - Time.time).ToString("F2");
        if (gameTime <= Time.time)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        if (gameHasEnded)
        {
            return;
        }

        rotator.enabled = false;
        spawner.enabled = false;

        animator.SetTrigger("EndGame");
        livesLeft--;
        gameHasEnded = true;
    }

    public void RestartLevel()
    {
        scoreList.Add(Score.pinCount);
        if (livesLeft <= 0)
        {
            SceneManager.LoadScene("Exit");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
