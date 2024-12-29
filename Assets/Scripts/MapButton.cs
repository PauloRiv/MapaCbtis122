using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena que queremos cargar

    void Update()
    {
        // Verifica si hay un toque en la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Detectar si el toque ha comenzado
            if (touch.phase == TouchPhase.Began)
            {
                // Convertir la posici�n del toque a coordenadas del mundo
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // Verificar si el toque coincide con este objeto
                Collider2D hitCollider = Physics2D.OverlapPoint(touchPosition);

                if (hitCollider != null && hitCollider.gameObject == gameObject)
                {
                    // Cambiar a la escena especificada
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        }
    }
}
