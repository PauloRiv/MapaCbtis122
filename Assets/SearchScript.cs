using UnityEngine;
using UnityEngine.UI;
using TMPro; // Solo si usas TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections.Generic; // Para usar Dictionary
using System.IO; // Para manejar archivos

public class SceneSearch : MonoBehaviour
{
    [SerializeField] private TMP_InputField searchInput; // Cambia a InputField si no usas TMP
    [SerializeField] private Button searchButton;

    // Diccionario para mapear palabras clave a nombres de escena
    private Dictionary<string, string> sceneMap = new Dictionary<string, string>();

    void Start()
    {
        // Cargar el mapeo de escenas desde el JSON
        LoadSceneMap();

        // Enlazar el botón al método de búsqueda
        searchButton.onClick.AddListener(OnSearch);
    }

    private void LoadSceneMap()
    {
        // Cargar el archivo JSON desde la carpeta Resources
        TextAsset jsonFile = Resources.Load<TextAsset>("SceneMap");

        if (jsonFile != null)
        {
            // Convertir el JSON a un diccionario
            sceneMap = JsonUtility.FromJson<SceneMapWrapper>(jsonFile.text).ToDictionary();
            Debug.Log("Mapa de escenas cargado correctamente.");
        }
        else
        {
            Debug.LogError("El archivo SceneMap.json no se encontró en la carpeta Resources.");
        }
    }

    private void OnSearch()
    {
        string userInput = searchInput.text.Trim().ToLower();

        if (sceneMap.TryGetValue(userInput, out string sceneName))
        {
            Debug.Log($"Cargando escena: {sceneName}");
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("La escena no existe o no está configurada.");
        }
    }

    [System.Serializable]
    private class SceneMapWrapper
    {
        public List<SceneMapping> mappings;

        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var mapping in mappings)
            {
                dictionary[mapping.keyword] = mapping.sceneName;
            }
            return dictionary;
        }
    }

    [System.Serializable]
    private class SceneMapping
    {
        public string keyword;
        public string sceneName;
    }
}
