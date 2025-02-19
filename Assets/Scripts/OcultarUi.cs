using UnityEngine;
using UnityEngine.UI;

public class RoomChangeUI : MonoBehaviour
{
    public GameObject habitacionActual;
    public GameObject habitacionDestino;
    public Button botonCambio; // Asigna el bot�n desde el Inspector

    void Start()
    {
        // Asigna el m�todo al bot�n
        if (botonCambio != null)
            botonCambio.onClick.AddListener(CambiarHabitacion);
    }

    void CambiarHabitacion()
    {
        if (habitacionActual != null) habitacionActual.SetActive(false);
        if (habitacionDestino != null) habitacionDestino.SetActive(true);
    }
}
