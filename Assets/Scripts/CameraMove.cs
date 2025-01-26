using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove: MonoBehaviour
{
    public Camera mainCamera;
    public float panSpeed = 0.5f;

    // L�mites para el movimiento de la c�mara
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

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
            Vector3 newPosition = mainCamera.transform.position + direction;

            // Aplicar l�mites al movimiento
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            // Actualizar la posici�n de la c�mara
            mainCamera.transform.position = newPosition;
        }
    }

    private void OnDisable()
    {
        // Desactivar la acci�n cuando el script no est� activo
        panAction.Disable();
    }
}
