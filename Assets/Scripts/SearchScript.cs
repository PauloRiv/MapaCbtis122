using UnityEngine;
using UnityEngine.UI;
using TMPro; // Para TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SearchWithAutocomplete : MonoBehaviour
{
    [SerializeField] private TMP_InputField searchInput;  // Campo de b�squeda
    [SerializeField] private GameObject suggestionTemplate; // Bot�n de plantilla (Prefab)
    [SerializeField] private Transform suggestionContainer; // Contenedor de sugerencias (Content del ScrollRect)
    [SerializeField] private ScrollRect scrollRect; // ScrollRect para manejar las sugerencias

    // Mapa de t�rminos de b�squeda y las escenas correspondientes
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
        // Aseg�rate de que el ScrollRect est� oculto al inicio
        scrollRect.gameObject.SetActive(false);

        // Escucha los cambios en el campo de b�squeda
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
        // Instanciar un bot�n basado en la plantilla
        GameObject suggestion = Instantiate(suggestionTemplate, suggestionContainer);

        // Asegurarse de que el bot�n est� activo
        suggestion.SetActive(true);

        // Configurar el texto del bot�n
        TMP_Text suggestionText = suggestion.GetComponentInChildren<TMP_Text>();
        suggestionText.text = keyword;

        // Asignar la funci�n al bot�n
        Button suggestionButton = suggestion.GetComponent<Button>();
        suggestionButton.onClick.AddListener(() => LoadScene(sceneName));

        // A�adir a la lista de sugerencias activas
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
