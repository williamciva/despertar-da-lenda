using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore, totalScoreBackup;
    public Text scoreText;
    public GameObject gameOver;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        totalScoreBackup = PlayerPrefs.GetInt("score");
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        SaveScore(); 
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString("0000");
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene("Level_1");
        totalScore = PlayerPrefs.GetInt("score");
        scoreText.text = totalScore.ToString("0000");
    }

    public void RestartGame(string levelName)
    {
        totalScore = totalScoreBackup;
        SceneManager.LoadScene(levelName);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", totalScore);
    }

    public void LoadScore()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            totalScore = 0;
            scoreText.text = totalScore.ToString("0000");
        }
        else
        {
            totalScore = PlayerPrefs.GetInt("score");
            scoreText.text = totalScore.ToString("0000");
        }
    }
}
