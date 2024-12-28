using UnityEngine;

public class MapaMovment : MonoBehaviour
{
    // Configuración de los límites del zoom
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 2.0f;
    [SerializeField] private float zoomSpeed = 0.1f;

    // Configuración de la velocidad de rotación
    [SerializeField] private float rotationSpeed = 0.2f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Verifica si hay dos toques en la pantalla
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // ** Zoom: Calcula la distancia entre los dedos en el fotograma actual y el anterior **
            float prevTouchDeltaMag = (touch1.position - touch1.deltaPosition - (touch2.position - touch2.deltaPosition)).magnitude;
            float touchDeltaMag = (touch1.position - touch2.position).magnitude;
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // Ajusta el tamaño del Sprite
            float newScale = Mathf.Clamp(transform.localScale.x - deltaMagnitudeDiff * zoomSpeed * Time.deltaTime, minScale, maxScale);
            transform.localScale = new Vector3(newScale, newScale, newScale);

            // ** Rotación: Calcula el ángulo entre los dedos **
            Vector2 prevTouch1 = touch1.position - touch1.deltaPosition;
            Vector2 prevTouch2 = touch2.position - touch2.deltaPosition;

            float prevAngle = Mathf.Atan2(prevTouch2.y - prevTouch1.y, prevTouch2.x - prevTouch1.x) * Mathf.Rad2Deg;
            float currentAngle = Mathf.Atan2(touch2.position.y - touch1.position.y, touch2.position.x - touch1.position.x) * Mathf.Rad2Deg;

            // Determina la diferencia de ángulo y aplica la rotación
            float angleDelta = currentAngle - prevAngle;
            transform.Rotate(Vector3.forward, angleDelta * rotationSpeed);
        }
    }
}

