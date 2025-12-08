using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip finishSound;
    
    private UIManager _uiManager;
    private void Awake()
    {
        _uiManager = FindAnyObjectByType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Debug.Log("Level completed!");
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(finishSound);
        _uiManager.Win();
    }
}