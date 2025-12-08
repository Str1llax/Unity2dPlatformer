using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private AudioClip coinPickup;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        SoundManager.Instance.GetComponentInChildren<SFXManager>().PlaySound(coinPickup);
        collision.GetComponent<CoinManager>().AddCoin(value);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}