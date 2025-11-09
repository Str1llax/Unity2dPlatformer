using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float pickupDistance = 1.5f; 

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= pickupDistance)
            {
                PickUp();
            }
        }
    }

    void PickUp()
    {
        GameManager.Instance.AddCoin(1);
        Destroy(gameObject);
    }
}