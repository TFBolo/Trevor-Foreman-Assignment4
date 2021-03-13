using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text finalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.scoreList.Sort();
        finalScoreText.text = GameManager.scoreList[GameManager.scoreList.Count - 1].ToString();
        GameManager.scoreList.Clear();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Intro");
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
