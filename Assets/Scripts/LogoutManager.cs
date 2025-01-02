using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoutManager : MonoBehaviour
{
    public void Logout()
    {
        // Eliminar el usuario activo
        PlayerPrefs.DeleteKey("ActiveUser");

        // Volver a la escena de inicio de sesión
        SceneManager.LoadScene("LoginScene");
    }
}
