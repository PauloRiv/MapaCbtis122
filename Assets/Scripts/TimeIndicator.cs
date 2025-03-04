using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class TimeSprite
{
    public int startHour;
    public int startMinute;
    public int endHour;
    public int endMinute;
    public Sprite sprite;
}

public class TimeIndicator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<TimeSprite> timeSprites = new List<TimeSprite>();
    public Sprite defaultSprite;

    void Start()
    {
        UpdateSprite();
        InvokeRepeating(nameof(UpdateSprite), 60, 60);
    }

    void UpdateSprite()
    {
        int currentHour = DateTime.Now.Hour;
        int currentMinute = DateTime.Now.Minute;

        foreach (var timeSprite in timeSprites)
        {
            if (IsWithinTimeRange(currentHour, currentMinute, timeSprite))
            {
                spriteRenderer.sprite = timeSprite.sprite;
                return;
            }
        }

        spriteRenderer.sprite = defaultSprite;
    }

    bool IsWithinTimeRange(int hour, int minute, TimeSprite timeSprite)
    {
        TimeSpan currentTime = new TimeSpan(hour, minute, 0);
        TimeSpan startTime = new TimeSpan(timeSprite.startHour, timeSprite.startMinute, 0);
        TimeSpan endTime = new TimeSpan(timeSprite.endHour, timeSprite.endMinute, 0);

        return currentTime >= startTime && currentTime < endTime;
    }
}
