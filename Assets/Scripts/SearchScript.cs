using UnityEngine;
using UnityEngine.UI;
using TMPro; // Para TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SearchWithAutocomplete : MonoBehaviour
{
    [SerializeField] private TMP_InputField searchInput;  // Campo de búsqueda
    [SerializeField] private GameObject suggestionTemplate; // Botón de plantilla (Prefab)
    [SerializeField] private Transform suggestionContainer; // Contenedor de sugerencias (Content del ScrollRect)
    [SerializeField] private ScrollRect scrollRect; // ScrollRect para manejar las sugerencias

    // Mapa de términos de búsqueda y las escenas correspondientes
    private Dictionary<string, string> sceneMap = new Dictionary<string, string>()
    {
        { "maoa", "Map" },
        { "laboratorio computo", "LabComputo" },
        { "lc", "LabComputo" },
        { "maestros", "Teachers" }
    };

    // Lista para gestionar los botones de sugerencias creados
    private List<GameObject> activeSuggestions = new List<GameObject>();

    void Start()
    {
        // Asegúrate de que el ScrollRect esté oculto al inicio
        scrollRect.gameObject.SetActive(false);

        // Escucha los cambios en el campo de búsqueda
        searchInput.onValueChanged.AddListener(OnInputChanged);
    }

    private void OnInputChanged(string userInput)
    {
        ClearSuggestions(); // Limpiar sugerencias anteriores

        if (string.IsNullOrWhiteSpace(userInput))
        {
            scrollRect.gameObject.SetActive(false); // Ocultar sugerencias si no hay texto
            return;
        }

        userInput = userInput.Trim().ToLower(); // Normalizar entrada
        foreach (var entry in sceneMap)
        {
            if (entry.Key.Contains(userInput)) // Buscar coincidencias
            {
                AddSuggestion(entry.Key, entry.Value);
            }
        }

        // Mostrar la barra de sugerencias solo si hay elementos
        scrollRect.gameObject.SetActive(activeSuggestions.Count > 0);
    }

    private void AddSuggestion(string keyword, string sceneName)
    {
        // Instanciar un botón basado en la plantilla
        GameObject suggestion = Instantiate(suggestionTemplate, suggestionContainer);

        // Asegurarse de que el botón esté activo
        suggestion.SetActive(true);

        // Configurar el texto del botón
        TMP_Text suggestionText = suggestion.GetComponentInChildren<TMP_Text>();
        suggestionText.text = keyword;

        // Asignar la función al botón
        Button suggestionButton = suggestion.GetComponent<Button>();
        suggestionButton.onClick.AddListener(() => LoadScene(sceneName));

        // Añadir a la lista de sugerencias activas
        activeSuggestions.Add(suggestion);
    }

    private void ClearSuggestions()
    {
        // Eliminar todos los botones de sugerencias activas
        foreach (var suggestion in activeSuggestions)
        {
            Destroy(suggestion);
        }

        activeSuggestions.Clear();
    }

    private void LoadScene(string sceneName)
    {
        // Cargar la escena seleccionada
        SceneManager.LoadScene(sceneName);
    }
}
