using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    // M�todo p�blico que se llama desde el bot�n
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}