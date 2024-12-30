using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // M�todo p�blico que se llama desde el bot�n
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}