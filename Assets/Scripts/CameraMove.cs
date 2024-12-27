using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomSpeed = 0.1f;
    public float minZoom = 2f;
    public float maxZoom = 10f;
    public float panSpeed = 0.5f;

    private Vector2 touchStart;
    private Vector3 cameraStartPosition;
    private InputAction panAction;
    private InputAction zoomAction;

    void Awake()
    {
        // Inicializar acciones de entrada
        panAction = new InputAction("Pan", binding: "<Pointer>/delta");
        zoomAction = new InputAction("Zoom", binding: "<Pointer>/scroll");

        panAction.Enable();
        zoomAction.Enable();

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        Vector2 panDelta = panAction.ReadValue<Vector2>();
        Vector2 zoomDelta = zoomAction.ReadValue<Vector2>();

        // Movimiento (Pan)
        if (panDelta != Vector2.zero)
        {
            Vector3 direction = new Vector3(-panDelta.x, -panDelta.y, 0) * panSpeed * Time.deltaTime;
            mainCamera.transform.position += direction;
        }

        // Zoom
        if (zoomDelta.y != 0)
        {
            float increment = -zoomDelta.y * zoomSpeed * Time.deltaTime;
            Zoom(increment);
        }
    }

    private void Zoom(float increment)
    {
        float newSize = Mathf.Clamp(mainCamera.orthographicSize - increment, minZoom, maxZoom);
        mainCamera.orthographicSize = newSize;
    }

    private void OnDisable()
    {
        panAction.Disable();
        zoomAction.Disable();
    }
}

