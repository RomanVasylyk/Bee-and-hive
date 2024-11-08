using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hivescript : MonoBehaviour
{
    private int lives = 5;
    private static int highestScore = 0;
    public GameObject menuPanel;
    private bool gameEnded = false;
    public TMP_Text scoreDisplay;
    public TMP_Text timeDisplay;
    public pleyer playerInstance;
    private int score;
    private float timer;
    public TMP_Text highestScoreDisplay;

    void Start()
    {
        playerInstance = FindObjectOfType<pleyer>();
        if(menuPanel != null)
            menuPanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded)
        {
            Time.timeScale = 0f;
        }
        score = playerInstance.GetScore();
        timer = playerInstance.GetTimer();
    }

    private void OnCollisionEnter2D(Collision2D other) { 
        if (gameEnded)
            return;
        if (other.gameObject.tag == "Enemy") {
                lives = lives-1;
                if(lives>=1){
                    Destroy(GameObject.Find("hive "+lives));
                    Destroy(other.gameObject);
                }else{
                    PlayerPrefs.SetInt("result", 0);
                    if(menuPanel != null){
                    menuPanel.SetActive(true);
                    gameEnded = true;
                    scoreDisplay.text = "Score: " + score;
                    timeDisplay.text = "Time: " + timer.ToString("F1");
                    
                    if (score > highestScore)
                    {
                        highestScore = score;
                        PlayerPrefs.SetInt("highestScore", highestScore); 
                    }
                    highestScoreDisplay.text = "Highest Score: " + highestScore;
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in enemies)
                    {
                        Destroy(enemy);
                    }
                    }
                }
        }
    }
    public void RestartGame()
    {
        lives = 5;
        gameEnded = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
        
}