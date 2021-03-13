using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static float speedMod = 1;
    public static bool musicOn = true;
    public static float pinSpeed = 1;
    public static int lives = 3;
    public static float timer = 30;
    public static string playerName;

    public Text speedText;
    public Slider speedSlider;
    public Toggle toggle;
    public Text pinText;
    public Slider pinSlider;
    public Dropdown livesDropdown;
    public Slider timerSlider;
    public Text timerText;
    public InputField nameField;

    public void Awake()
    {
        // 1
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            toggle.isOn = true;
            musicOn = true;
            PlayerPrefs.Save();
        }
        // 2
        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                toggle.isOn = false;
                musicOn = false;
            }
            else
            {
                toggle.isOn = true;
                musicOn = true;
            }
        }
    }

    public void Start()
    {
        speedSlider.value = speedMod * 100;
        toggle.isOn = musicOn;
        livesDropdown.value = lives - 1;
        timerSlider.value = timer;
        nameField.text = playerName;
        pinSlider.value = pinSpeed * 100;
    }

    public void SpeedChange()
    {
        speedMod = speedSlider.value / 100;
        speedText.text = "Rotator Speed (" + (speedMod * 100) + "%)";
    }

    public void PinSpeedChange()
    {
        pinSpeed = pinSlider.value / 100;
        pinText.text = "Pin Speed (" + (pinSpeed * 100) + "%)";
    }

    public void LifeChange()
    {
        lives = livesDropdown.value + 1;
    }

    public void TimerChange()
    {
        timer = timerSlider.value;
        timerText.text = "Playtime: " + timer.ToString("F0");
    }

    public void nameChange()
    {
        playerName = nameField.text;
    }

    public void ToggleMusic()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            musicOn = true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            musicOn = false;
        }
        PlayerPrefs.Save();
    }

    public void StartGame()
    {
        GameManager.livesLeft = lives;
        SceneManager.LoadScene("MainLevel");
    }
}
