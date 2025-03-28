using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public GameObject creditPanel;
    
    public Button startButton;
    public Button homeButton;
    public Button creditButton;
    public Button backButton;
    
    private PlayerController playerController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        gameOverPanel.SetActive(false);
    }

    private void Start()
    {
        playerController = GameObject.Find("Car").GetComponent<PlayerController>();
        
        MainMenu();
        
        startButton.onClick.AddListener(StartGame);
        homeButton.onClick.AddListener(Home);
        creditButton.onClick.AddListener(Credit);
        backButton.onClick.AddListener(MainMenu);
    }

    public void MainMenu()
    {
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        creditPanel.SetActive(false);
        
        Time.timeScale = 0f;
        playerController.enabled = false;
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        creditPanel.SetActive(false);
        
        Time.timeScale = 1f;
        playerController.enabled = true;
    }

    public void GameOver()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(true);
        creditPanel.SetActive(false);
        
        Time.timeScale = 0f;
        playerController.enabled = false;
    }

    public void Home()
    {
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        creditPanel.SetActive(false);
        
        Time.timeScale = 1f;
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void Credit()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        creditPanel.SetActive(true);
        
        Time.timeScale = 0f;
        playerController.enabled = false;
    }
}