using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    private bool isOn = true;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    [ContextMenu("Increment Score")]
    public void UpdateScore(int add)
    {
        playerScore += add;
        scoreText.text = playerScore.ToString();
        SaveHighScore();
    }

    public void SaveHighScore()
    {
        if (playerScore <= PlayerPrefs.GetInt("HighScore")) return;
        
        PlayerPrefs.SetInt("HighScore", playerScore);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void PauseGame()
    {
        if (!Input.GetKeyDown(KeyCode.P)) return;

        Time.timeScale = isOn ? 0 : 1;

        isOn = !isOn;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Launch Screen");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
