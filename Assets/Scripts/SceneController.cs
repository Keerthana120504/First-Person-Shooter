using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Load the Level1 scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        if (Time.timeScale >= 0)
        {
            Time.timeScale = 1;
        }
    }

    // Quit the application
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");  // This will only show in the editor
    }

    // Reload the current scene (used for Try Again button in Level1)
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale >= 0)
        {
            Time.timeScale = 1;
        }
    }

    // Return to Main Menu
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
