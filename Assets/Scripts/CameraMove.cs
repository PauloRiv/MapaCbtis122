using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public float panSpeed = 0.5f;

    private InputAction panAction;

    void Awake()
    {
        // Inicializar la acci�n de movimiento
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
            // Aplicar el movimiento a la c�mara
            Vector3 direction = new Vector3(-panDelta.x, -panDelta.y, 0) * panSpeed * Time.deltaTime;
            mainCamera.transform.position += direction;
        }
    }

    private void OnDisable()
    {
        // Desactivar la acci�n cuando el script no est� activo
        panAction.Disable();
    }
}
