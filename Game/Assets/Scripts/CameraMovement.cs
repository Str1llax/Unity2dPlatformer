using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float cameraFollowSpeed;
    [Range(0, 1)] [SerializeField] private float cameraZoomSpeed;
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private InputAction cameraZoom;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        cameraZoom.Enable();
    }
    private void Update()
    {
        transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y + _camera.orthographicSize/3f, -10f);
        Zoom();
    }

    private void Zoom()
    {
        if (!cameraZoom.IsPressed()) return;
        var zoom = cameraZoom.ReadValue<Vector2>();
        _camera.orthographicSize = zoom.y > 0 ? Math.Max(_camera.orthographicSize-cameraZoomSpeed, 2.5f) : Math.Min(_camera.orthographicSize+cameraZoomSpeed, 6f);
    }
}
