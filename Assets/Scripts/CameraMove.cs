using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public float panSpeed = 0.5f;

    private InputAction panAction;

    void Awake()
    {
        // Inicializar la acción de movimiento
        panAction = new InputAction("Pan", binding: "<Pointer>/delta");
        panAction.Enable();

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
        // Leer el delta del movimiento del puntero (touch o mouse)
        Vector2 panDelta = panAction.ReadValue<Vector2>();

        if (panDelta != Vector2.zero)
        {
            // Aplicar el movimiento a la cámara
            Vector3 direction = new Vector3(-panDelta.x, -panDelta.y, 0) * panSpeed * Time.deltaTime;
            mainCamera.transform.position += direction;
        }
    }

    private void OnDisable()
    {
        // Desactivar la acción cuando el script no esté activo
        panAction.Disable();
    }
}
