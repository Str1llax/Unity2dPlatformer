using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioClip clickSound;
    
    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuScreen;
    
    [Header("Settings")]
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject volumeScreen;
    [SerializeField] private GameObject controlScreen;

    private void Awake()
    {
        settingsScreen.SetActive(false);
        volumeScreen.SetActive(false);
    }

    #region Main Menu
    public void Settings()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
    
    public void StartGame()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        SceneManager.LoadScene(1);
    }
    
    public void Quit()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    #endregion
    
    #region Settings
    public void Volume()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        settingsScreen.SetActive(false);
        volumeScreen.SetActive(true);
    }

    public void Controls()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        return;
        //TODO create a customizable controls
        settingsScreen.SetActive(false);
        controlScreen.SetActive(true);
    }
    
    public void GoBack()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        settingsScreen.SetActive(false);
        volumeScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
    #endregion
    
    #region Volume
    public void ChangeMasterVolume()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        SoundManager.Instance.ChangeMasterVolume(0.2f);
    }

    public void ChangeMusicVolume()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        SoundManager.Instance.ChangeMusicVolume(0.2f);
    }

    public void ChangeSfxVolume()
    {
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(clickSound);
        SoundManager.Instance.ChangeSfxVolume(0.2f);
    }
    #endregion

}
