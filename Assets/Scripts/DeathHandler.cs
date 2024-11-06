using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    // Private
    [SerializeField] Canvas mainCanvas;
    [SerializeField] Canvas gameOverCanvas;

    // Public


    // Start is called before the first frame update
    void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.gameObject.SetActive(false);  // Hide game over canvas at start
        }
        if (mainCanvas != null)
        {
            mainCanvas.gameObject.SetActive(true);  // Ensure main canvas is active
        }
    }

    // Update is called once per frame
    public void HandleDeath()
    {
        if (mainCanvas != null)
        {
            mainCanvas.gameObject.SetActive(false);  // Hide the main canvas
        }

        if (gameOverCanvas != null)
        {
            gameOverCanvas.gameObject.SetActive(true);  // Show the game over canvas
        }

        Time.timeScale = 0;  // Pause the game
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        Cursor.visible = true;  // Make the cursor visible
    }
}
