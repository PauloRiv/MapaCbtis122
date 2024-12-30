using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public int pageIndex; // �ndice de la p�gina asociada a este bot�n

    public void OnButtonClick()
    {
        // Guardar el �ndice de la p�gina seleccionada
        PlayerPrefs.SetInt("SelectedPage", pageIndex);

        // Cargar la escena base
        SceneManager.LoadScene("TeacherInfo");
    }
}

