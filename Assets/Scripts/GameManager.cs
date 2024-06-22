using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerLives = 3;
    public string titleScene = "TitleScene";
    public string gameScene = "LevelScene";
    public string gameOverScene = "GameOverScene";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Optionally, you can load the title scene at the start
        SceneManager.LoadScene(titleScene);
    }

    public void StartGame()
    {
        playerLives = 3;
        SceneManager.LoadScene(gameScene);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOverScene);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene(titleScene);
    }

    public void LoseLife()
    {
        playerLives--;
        if (playerLives <= 0)
        {
            GameOver();
        }
        else
        {
            // Respawn player or reload the game scene
            SceneManager.LoadScene(gameScene);
        }
    }
}
