using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Hamster")] 
    [SerializeField] private Hamster hamster;

    [Header("Score UI")] 
    [SerializeField] private GameObject scoreUI;

    [Header("GameOver UI")] 
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    private DistanceCount distanceCount;
    
    [Header("Paused")]
    [SerializeField] private bool isPaused = false;

    [SerializeField] private GameObject pausedPanel;
    [SerializeField] private TextMeshProUGUI scoreTextPaused;
    [SerializeField] private TextMeshProUGUI highScoreTextPaused;


    private void Start()
    {
        distanceCount = GetComponent<DistanceCount>();
    }

    public void Update()
    {
        GameOver();
        PausePanel();
    }

    public void GameOver()
    {
        if (!hamster)
        { 
            Debug.Log("Game Over");
            Time.timeScale = 0.5f;
            scoreUI.SetActive(false);
            gameOverPanel.SetActive(true);
            scoreText.text = "Score : " + distanceCount.MaxDistance.ToString("F0") + " M";
            highScoreText.text = "High Score : " + distanceCount.HighScore.ToString("F0") + " M";
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
        SceneManager.LoadScene(0);
    }
}
