using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public int pageIndex; // Índice de la página asociada a este botón

    public void OnButtonClick()
    {
        // Guardar el índice de la página seleccionada
        PlayerPrefs.SetInt("SelectedPage", pageIndex);

        // Cargar la escena base
        SceneManager.LoadScene("TeacherInfo");
    }
}

