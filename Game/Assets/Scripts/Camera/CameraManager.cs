using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Camera borders")]
    [SerializeField] private Vector2 xLimits;
    [SerializeField] private Vector2 yLimits;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;
        if (Camera.main != null) Camera.main.GetComponent<CameraMovement>().SetCameraBorders(xLimits, yLimits);
    }
}
