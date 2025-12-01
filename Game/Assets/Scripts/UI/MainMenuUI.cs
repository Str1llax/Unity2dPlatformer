using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuScreen;
    
    
    #region Main Menu

    public void Settings()
    {
        //TODO create a settings menu    
        mainMenuScreen.SetActive(false);
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

}
