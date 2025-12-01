using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
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
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Quit()
    {
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
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
    #endregion

}
