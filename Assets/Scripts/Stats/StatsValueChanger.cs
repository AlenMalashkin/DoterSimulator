using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsValueChanger : MonoBehaviour
{
    public event Action<float, Stats> OnStatsValueChangedEvent;
    
    private Dictionary<Stats, string> statsMap = new Dictionary<Stats, string>()
    {
        {Stats.Hungry, "Hungry"},
        {Stats.Mood, "Mood"},
        {Stats.Sleepy, "Sleepy"},
    };
    
    public void IncreaseStats(float consumption, Stats stat)
    {
        var statValue = PlayerPrefs.GetFloat(statsMap[stat], 1f);

        statValue += consumption;


        if (statValue >= 1)
        {
            statValue = 1;
        }

        PlayerPrefs.SetFloat(statsMap[stat], statValue);

        OnStatsValueChangedEvent?.Invoke(statValue, stat);
    }

    public void DecreaseStats(float consumption, Stats stat)
    {
        var statValue = PlayerPrefs.GetFloat(statsMap[stat], 1f);

        statValue -= consumption;


        if (statValue <= 0)
        {
            statValue = 0;
        }

        PlayerPrefs.SetFloat(statsMap[stat], statValue);

        OnStatsValueChangedEvent?.Invoke(statValue, stat);
    }
}
