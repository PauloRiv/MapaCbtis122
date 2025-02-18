using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoControl : MonoBehaviour
{
    public TextMeshProUGUI nameText; // Referencia al texto del título
    public TextMeshProUGUI infoText; // Referencia al texto principal
    public Image teacherImage; // Referencia a la imagen principal
    public Image teacherTable;

    // Datos de ejemplo para diferentes páginas
    private string[] pageNames = { "Raúl Alberto Toledo Piñón", "Pilar Eduardo Sierra Muñit", "Griselda Salas Santos" };
    private string[] pageInfos = {
        "El profesor Toledo imparte materias didácticas y enfocadas a la programación, como las cuales son: Cultura Digital, Aplicación Web y Desarrollo de Aplicación Web",
        "El profesor Sierra imparte materias de programacion.",
        "La profesora Salas imparte materias de fisica."
    };

    [SerializeField] private Sprite[] pageImages;
    [SerializeField] private Sprite[] pageTable;

    void Start()
    {
        // Recuperar el índice de la página seleccionada
        int selectedPage = PlayerPrefs.GetInt("SelectedPage", 0); // Valor predeterminado: 0

        // Llamar al método para cargar la página correspondiente
        LoadPage(selectedPage);
    }
    public void LoadPage(int pageIndex)
    {
        // Validar índice
        if (pageIndex < 0 || pageIndex >= pageNames.Length) return;

        // Actualizar contenido
        nameText.text = pageNames[pageIndex];
        infoText.text = pageInfos[pageIndex];
        if (pageImages != null && pageIndex < pageImages.Length)
        {
            teacherImage.sprite = pageImages[pageIndex];
            teacherTable.sprite = pageTable[pageIndex];
        }
    }
}
