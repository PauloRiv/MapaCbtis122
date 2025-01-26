using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoControl : MonoBehaviour
{
    public TextMeshProUGUI nameText; // Referencia al texto del t�tulo
    public TextMeshProUGUI infoText; // Referencia al texto principal
    public Image teacherImage; // Referencia a la imagen principal
    public Image teacherTable;

    // Datos de ejemplo para diferentes p�ginas
    private string[] pageNames = { "Ra�l Alberto Toledo Pi%�n", "P�gina 2", "P�gina 3" };
    private string[] pageInfos = {
        "El profesor Toledo imparte materias did�cticas y enfocadas a la programaci�n, como las cuales son: Cultura Digital, Aplicaci�n Web y Desarrollo de Aplicaci�n Web",
        "Contenido de la p�gina 2.",
        "Contenido de la p�gina 3."
    };

    [SerializeField] private Sprite[] pageImages;
    [SerializeField] private Sprite[] pageTable;

    void Start()
    {
        // Recuperar el �ndice de la p�gina seleccionada
        int selectedPage = PlayerPrefs.GetInt("SelectedPage", 0); // Valor predeterminado: 0

        // Llamar al m�todo para cargar la p�gina correspondiente
        LoadPage(selectedPage);
    }
    public void LoadPage(int pageIndex)
    {
        // Validar �ndice
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
