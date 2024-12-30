using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Método público que se llama desde el botón
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}