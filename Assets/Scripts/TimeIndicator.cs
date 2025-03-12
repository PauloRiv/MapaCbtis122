using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

[Serializable]
public class TimeText
{
    public int startHour;
    public int startMinute;
    public int endHour;
    public int endMinute;
    public string grupo; // Texto a mostrar
    public string profe;
    public List<DayOfWeek> allowedDays = new List<DayOfWeek>(); // Días en los que se activa
}

public class TimeIndicator : MonoBehaviour
{
    public TextMeshPro Grupo;
    public TextMeshPro Profe;
    public List<TimeText> timeTexts = new List<TimeText>();
    public string defaultText = "Texto por defecto"; // Texto si no hay coincidencias

    void Start()
    {
        UpdateText();
        InvokeRepeating(nameof(UpdateText), 60, 60); // Se actualiza cada minuto
    }

    void UpdateText()
    {
        int currentHour = DateTime.Now.Hour;
        int currentMinute = DateTime.Now.Minute;
        DayOfWeek currentDay = DateTime.Now.DayOfWeek;

        foreach (var timeText in timeTexts)
        {
            if (IsWithinTimeRange(currentHour, currentMinute, timeText) && timeText.allowedDays.Contains(currentDay))
            {
                Grupo.text = timeText.grupo;
                Profe.text = timeText.profe;
                return;
            }
        }

        // Si no encuentra coincidencias, usa el texto predeterminado
        Grupo.text = defaultText;
        Profe.text = defaultText;
    }

    bool IsWithinTimeRange(int hour, int minute, TimeText timeText)
    {
        TimeSpan currentTime = new TimeSpan(hour, minute, 0);
        TimeSpan startTime = new TimeSpan(timeText.startHour, timeText.startMinute, 0);
        TimeSpan endTime = new TimeSpan(timeText.endHour, timeText.endMinute, 0);

        return currentTime >= startTime && currentTime < endTime;
    }
}
