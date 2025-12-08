using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private int healthValue;
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (collision.GetComponent<Health>().IsAtMaxHealth()) return;
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(pickupSound);
        collision.GetComponent<Health>().AddHealth(healthValue);
        gameObject.SetActive(false);
    }
}
