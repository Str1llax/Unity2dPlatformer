using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera Movement")]
    [Range(0, 10)] [SerializeField] private float cameraFollowSpeed;
    [Range(0, 1)] [SerializeField] private float cameraZoomSpeed;
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private Vector2 xLimits;
    [SerializeField] private Vector2 yLimits;
    
    [Header("Keybinds")]
    [SerializeField] private InputActionReference cameraZoom;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(objectToFollow.position.x, xLimits.x, xLimits.y), Mathf.Clamp(objectToFollow.position.y + _camera.orthographicSize/3f, yLimits.x, yLimits.y), -10f);
        if (cameraZoom.action.ReadValue<Vector2>().y < 0)
        {
            Zoom(false);
        } else if (cameraZoom.action.ReadValue<Vector2>().y > 0)
        {
            Zoom(true);
        }
    }

    private void Zoom(bool negative)
    {
        _camera.orthographicSize = negative ? Math.Max(_camera.orthographicSize-cameraZoomSpeed, 2.5f) : Math.Min(_camera.orthographicSize+cameraZoomSpeed, 5f);
    }

    public void SetCameraBorders(Vector2 xBorders, Vector2 yBorders)
    {
        xLimits = xBorders;
        yLimits = yBorders;
    }
}
