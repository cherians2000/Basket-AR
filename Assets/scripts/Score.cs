using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public ParticleSystem BoomEffect;
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ballLeft;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreTextOnGameOver; 
    public TextMeshProUGUI hScoreTextOnGameOver;
    private int score=0;
    private int highScore =0;

    private const string HighScoreKey = "HighScore";
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }
    private void Update()
    {
        ballLeft.text = SpawnBall.chance.ToString();
    }
    public void Scored(int _score, Vector3 position)
    {
       
        score += _score;
        UpdateScoreText();

        if(score > highScore)
        {
            Instantiate(BoomEffect, position, Quaternion.identity).Play();
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            PlayerPrefs.Save();
        }
        UpdateHighScoreText();

        
    }
    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = highScore.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreTextOnGameOver.text= score.ToString();
        hScoreTextOnGameOver.text=highScore.ToString();
       
        scoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);

    }
    public void Play()
    {
        SpawnBall.chance = 10;
        SceneManager.LoadScene("BasketBall");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        ScoreManager.instance.highScore = 0;
        ScoreManager.instance.UpdateHighScoreText();
    }
}
