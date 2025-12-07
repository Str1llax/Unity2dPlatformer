using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [Range(1, 10)] [SerializeField] private int startingHealth;
    [SerializeField] private bool godMode;
    
    [Header("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;
    
    [Header("Audio")]
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip deathSound;
    
    public float CurrentHealth { get; private set; }
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isDead;

    private void Awake()
    {
        CurrentHealth = startingHealth;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        if (godMode) return;
        CurrentHealth = Math.Clamp(CurrentHealth - damage, 0, startingHealth);
        if (CurrentHealth > 0)
        {
            SoundManager.Instance.PlaySound(hitSound);
            _animator.SetTrigger("hit");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (_isDead) return;
            SoundManager.Instance.PlaySound(deathSound);
            _animator.SetTrigger("die");
            GetComponent<PlayerController>().enabled = false;
            _isDead = true;
        }
    }

    public void AddHealth(float value)
    {
        CurrentHealth = Math.Clamp(CurrentHealth + value, 0, startingHealth);
    }

    public bool IsAtMaxHealth()
    {
        return (int) CurrentHealth == startingHealth;
    }

    public void MaxHeal()
    {
        AddHealth(startingHealth);
        _animator.ResetTrigger("die");
        _animator.Play("Idle");
        StartCoroutine(Invulnerability());
        GetComponent<PlayerController>().enabled = true;
        _isDead = false;
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            _spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
