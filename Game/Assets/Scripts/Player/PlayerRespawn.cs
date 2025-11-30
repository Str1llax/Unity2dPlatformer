using System;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private int livesCount;
    private Health _playerHealth;
    private int _currentLives;
    private UIManager _uiManager;

    private void Awake()
    {
        _currentLives = livesCount;
        _playerHealth = GetComponent<Health>();
        _uiManager = FindAnyObjectByType<UIManager>();
    }

    private void Respawn()
    {
        if (_playerHealth.CurrentHealth <= 0)
        {
            --_currentLives;
        }
        transform.position = respawnPoint.position;
        _playerHealth.MaxHeal();
    }

    public void CheckRespawn()
    {
        if (_currentLives <= 1)
        {
            _uiManager.GameOver();
            return;
        }
        Respawn();
    }
}
