using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    // Método público que se llama desde el botón
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}