using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InputActionReference pauseButton;
    [SerializeField] private AudioClip clickSound;
    
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    
    [Header("Level Complete")]
    [SerializeField] private GameObject winScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    private void Update()
    {
        if (!pauseButton.action.WasPressedThisFrame() || gameOverScreen.activeInHierarchy) return;
        PauseGame(!pauseScreen.activeInHierarchy);
    }

    #region Game Over
    public void GameOver()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void MainMenu()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        SceneManager.LoadScene(0);
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        pauseScreen.SetActive(status);
        
        Time.timeScale = status ? 0 : 1;
    }
    #endregion
    
    #region Level Complete

    public void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void NextLevel()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var nextSceneIndex = currentSceneIndex + 1;
        
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
            Debug.Log("This was the last level!");
        }
    }
    #endregion
}
