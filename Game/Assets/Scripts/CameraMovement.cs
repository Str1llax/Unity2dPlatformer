using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraFollowSpeed;
    public Transform playerPosition;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, cameraFollowSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
