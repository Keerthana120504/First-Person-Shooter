using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;  // Assign the PauseMenuPanel in the Inspector

    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause menu is disabled at the start
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1; // Set time scale to normal at start
    }

    void Update()
    {
        // Check if the player presses the "Escape" key to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // Toggles between pause and resume
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0; // Stop time
            pauseMenuPanel.SetActive(true); // Show pause menu
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Resume the game
            Time.timeScale = 1; // Resume time
            pauseMenuPanel.SetActive(false); // Hide pause menu
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Resume button function
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Exit button function
    public void ExitToMainMenu()
    {
        Time.timeScale = 1;  // Ensure time is normal when loading new scene
        SceneManager.LoadScene("MainMenu");  // Replace with your main menu scene name
    }
}
