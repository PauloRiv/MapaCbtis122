using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena
using TMPro;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button loginButton;
    public Button registerButton;
    public TextMeshProUGUI feedbackText;

    private string guestUsername = "Invitado";
    private string guestPassword = "1234";


    private void Start()
    {
        feedbackText.text = "";

        // Comprobar si hay un usuario activo
        if (PlayerPrefs.HasKey("ActiveUser"))
        {
            string activeUser = PlayerPrefs.GetString("ActiveUser");
            feedbackText.text = $"Bienvenido de nuevo, {activeUser}. Redirigiendo...";

            // Redirigir automáticamente a la escena principal
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            // Configurar listeners para los botones
            loginButton.onClick.AddListener(HandleLogin);
            registerButton.onClick.AddListener(HandleRegister);
        }
    }

    private void HandleLogin()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            feedbackText.text = "El usuario y la contraseña no pueden estar vacíos.";
            return;
        }

        // Verificar si es la cuenta de invitado
        if (username == guestUsername && password == guestPassword)
        {
            feedbackText.text = "Inicio de sesión como invitado exitoso. Redirigiendo...";

            // Guardar la sesión del usuario
            PlayerPrefs.SetString("ActiveUser", guestUsername);

            // Redirigir a la escena principal
            SceneManager.LoadScene("Map");
            return;
        }

        // Verificar si el usuario existe en PlayerPrefs
        if (PlayerPrefs.HasKey(username) && PlayerPrefs.GetString(username) == password)
        {
            feedbackText.text = "Inicio de sesión exitoso. Redirigiendo...";

            // Guardar la sesión del usuario
            PlayerPrefs.SetString("ActiveUser", username);

            // Redirigir a la escena principal
            SceneManager.LoadScene("Map");
        }
        else
        {
            feedbackText.text = "Usuario o contraseña incorrectos.";
        }
    }

    private void HandleRegister()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            feedbackText.text = "El usuario y la contraseña no pueden estar vacíos.";
            return;
        }

        if (PlayerPrefs.HasKey(username))
        {
            feedbackText.text = "Este usuario ya existe.";
        }
        else
        {
            PlayerPrefs.SetString(username, password);
            feedbackText.text = "Usuario registrado exitosamente. Ahora puedes iniciar sesión.";
        }
    }
}
