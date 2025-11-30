using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private int healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (collision.GetComponent<Health>().IsAtMaxHealth()) return;
        collision.GetComponent<Health>().AddHealth(healthValue);
        gameObject.SetActive(false);
    }
}
