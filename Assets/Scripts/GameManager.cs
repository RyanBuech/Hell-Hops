using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    private static GameManager instance;
    public GameObject player;
    public Text scoreText;
    public Transform playerTransform;
    public string newGame;
    public string playerLocation;

    float score = 0;

    void Update()
    {
        float y = player.transform.position.y;

        if (y > score)
        {
            score = (int)y;
            UpdateScoreHUD();
        }
    }

    public static GameManager Get()
    {
        return instance;
    }
    
    void UpdateScoreHUD()
    {
        scoreText.text = "SCORE: " + score;
    }

    void Start()
    {
        instance = this;
        UpdateScoreHUD();
    }

    public GameObject gameOverPanel;

    public void onPlayerDied()
    {
        gameOverPanel.SetActive(true);
    }

    public void OnPlayAgainPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void OnExitPressed()
    {
        SceneManager.LoadScene(newGame);
    }
   
}
    
