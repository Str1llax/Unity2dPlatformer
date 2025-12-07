using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioClip clickSound;
    
    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuScreen;
    
    [Header("Settings")]
    [SerializeField] private GameObject settingsScreen;

    private void Awake()
    {
        settingsScreen.SetActive(false);
    }

    #region Main Menu
    public void Settings()
    {
        SoundManager.Instance.PlaySound(clickSound);
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
    
    public void StartGame()
    {
        SoundManager.Instance.PlaySound(clickSound);
        SceneManager.LoadScene(1);
    }
    
    public void Quit()
    {
        SoundManager.Instance.PlaySound(clickSound);
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    #endregion
    
    #region Settings
    public void Volume()
    {
        
    }

    public void Controls()
    {
        
    }
    
    public void GoBack()
    {
        SoundManager.Instance.PlaySound(clickSound);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
    #endregion

}
