using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove: MonoBehaviour
{
    public Camera mainCamera;
    public float panSpeed = 0.5f;

    // Límites para el movimiento de la cámara
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

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
            Vector3 newPosition = mainCamera.transform.position + direction;

            // Aplicar límites al movimiento
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            // Actualizar la posición de la cámara
            mainCamera.transform.position = newPosition;
        }
    }

    private void OnDisable()
    {
        // Desactivar la acción cuando el script no esté activo
        panAction.Disable();
    }
}
