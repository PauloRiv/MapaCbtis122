using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionChecker : MonoBehaviour
{
    void Start()
    {
        // Verificar si hay un usuario activo
        if (!PlayerPrefs.HasKey("ActiveUser"))
        {
            Debug.Log("No hay una sesión activa. Redirigiendo a la pantalla de inicio...");

            // Redirigir a la escena de inicio de sesión
            SceneManager.LoadScene("LoginScene");
        }
    }
}
