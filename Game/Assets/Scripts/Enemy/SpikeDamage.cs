using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
