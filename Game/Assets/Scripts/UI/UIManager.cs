using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InputActionReference pauseButton;
    
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (!pauseButton.action.WasPressedThisFrame() || gameOverScreen.activeInHierarchy) return;
        PauseGame(!pauseScreen.activeInHierarchy);
    }

    #region Game Over
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        
        Time.timeScale = status ? 0 : 1;
    }
    #endregion
}
