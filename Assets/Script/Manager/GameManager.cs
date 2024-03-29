using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Hamster")] 
    private Hamster hamster;

    [Header("Score UI")] 
    [SerializeField] private GameObject scoreUI;

    [Header("Coin UI")]
    [SerializeField] private GameObject coinUI;
    
    [Header("GameOver UI")] 
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI totalCoinText;
    
    [Header("Win UI")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI winScoreText;
    [SerializeField] private TextMeshProUGUI winHighScoreText;
    [SerializeField] private TextMeshProUGUI winCoinText;
    [SerializeField] private TextMeshProUGUI winTotalCoinText;

    private DistanceCount distanceCount;
    private CoinSystem coinSystem;
    
    [Header("Paused")]
    [SerializeField] private bool isPaused = false;

    [SerializeField] private GameObject pausedPanel;
    [SerializeField] private TextMeshProUGUI scoreTextPaused;
    [SerializeField] private TextMeshProUGUI highScoreTextPaused;

    [Header("Shop Panel")]
    private ShopSystem shopSystem;

    
    private void Awake()
    {
        PlayerPrefs.SetInt("11",1);
    }
    private void Start()
    {
        SoundManager.Instance.StopSound();
        SoundManager.Instance.PlayMainMusic();
        
        hamster = FindObjectOfType<Hamster>().GetComponent<Hamster>();
        distanceCount = GetComponent<DistanceCount>();
        coinSystem = GetComponent<CoinSystem>();
        shopSystem = GetComponent<ShopSystem>();
    }

    public void Update()
    {
        GameOver();
        PausePanel();
        WinPanel();
        shopSystem.UpdateCoin();
    }

    public void GameOver()
    {
        if (!hamster)
        {
            Time.timeScale = 0.5f;
            scoreUI.SetActive(false);
            coinUI.SetActive(false);
            gameOverPanel.SetActive(true);
            
            // display score and highscore on game over panel
            scoreText.text = "Score : " + distanceCount.MaxDistance.ToString("F0") + " M";
            highScoreText.text = "High Score : " + distanceCount.HighScore.ToString("F0") + " M";
            
            // display coin and total coin on game over panel
            coinText.text = coinSystem.AmountCoin.ToString();
            totalCoinText.text = "Total Coins : " + coinSystem.TotalCoin.ToString();

        }
        else
        {
            if (!isPaused)
            {
                Time.timeScale = 1;
                gameOverPanel.SetActive(false);   
            }
            if (isPaused) Time.timeScale = 0;
        }
    }

    public void WinPanel()
    {
        if (winPanel.activeSelf)
        {
            winScoreText.text = "Score : " + distanceCount.MaxDistance.ToString("F0") + " M";
            winHighScoreText.text = "High Score : " + distanceCount.HighScore.ToString("F0") + " M";
                    
            winCoinText.text = coinSystem.AmountCoin.ToString();
            winTotalCoinText.text = "Total Coins : " + coinSystem.TotalCoin.ToString();
            Pause();
        }
        
    }

    public void PausePanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && hamster)
        {
            if (!isPaused)
            {
                Pause();
                scoreUI.SetActive(false);
                pausedPanel.SetActive(true);
                scoreTextPaused.text = "Score : " + distanceCount.MaxDistance.ToString("F0") + " M";
                highScoreTextPaused.text = "High Score : " + distanceCount.HighScore.ToString("F0") + " M";   
            } 
            else if (isPaused)
            {
                UnPause();
                scoreUI.SetActive(true);
                pausedPanel.SetActive(false);
            }
        }
    }

    #region -Button Functions-

    public void ResetScore()
    {
        Debug.Log("Reset Highscore");
        PlayerPrefs.DeleteKey("highscore");
    }

    public void ResetCoin()
    {
        Debug.Log("Reset Coin");
        PlayerPrefs.DeleteKey("TotalCoin");
    }

    public void Pause()
    {
        Debug.Log("Game Pause");
        Time.timeScale = 0;
        isPaused = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        isPaused = false;
        if (!isPaused)
        {
            scoreUI.SetActive(true);
            pausedPanel.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void FreeMoney()
    {
        coinSystem.IncreaseCoin(200);
    }
    
    #endregion

}