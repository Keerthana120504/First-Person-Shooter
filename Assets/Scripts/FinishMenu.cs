using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    [SerializeField] private GameObject FinishMenuPanel;  // Assign the PauseMenuPanel in the Inspector


    void Start()
    {
        // Ensure the pause menu is disabled at the start
        FinishMenuPanel.SetActive(false);
        Time.timeScale = 1; // Set time scale to normal at start
    }


    // Toggles between pause and resume
    public void ToggleFinish()
    {
        // Pause the game
        Time.timeScale = 0; // Stop time
        FinishMenuPanel.SetActive(true); // Show pause menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale >= 0)
        {
            Time.timeScale = 1;
        }
    }

    // Exit button function
    public void ExitToMainMenu()
    {
        Time.timeScale = 1;  // Ensure time is normal when loading new scene
        SceneManager.LoadScene("MainMenu");  // Replace with your main menu scene name
    }
}

