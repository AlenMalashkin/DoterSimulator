using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsValueChanger : MonoBehaviour
{
    public event Action<float> OnHungryValueChangedEvent;
    public event Action<float> OnMoodValueChangedEvent;
    public event Action<float> OnSleepyValueChangedEvent;

    private Dictionary<Stats, Action<float>> onValueChangedActionsMap;

    private Dictionary<Stats, string> statsMap = new Dictionary<Stats, string>()
    {
        {Stats.Hungry, "Hungry"},
        {Stats.Mood, "Mood"},
        {Stats.Sleepy, "Sleepy"},
    };

    private void Awake()
    {
        onValueChangedActionsMap = new Dictionary<Stats, Action<float>>()
        {
            {Stats.Hungry, OnHungryValueChangedEvent},
            {Stats.Mood, OnMoodValueChangedEvent},
            {Stats.Sleepy, OnSleepyValueChangedEvent}
        };
    }

    public void IncreaseStats(float consumption, Stats stat)
    {
        var statValue = PlayerPrefs.GetFloat(statsMap[stat], 1f);

        statValue += consumption;


        if (statValue >= 1)
        {
            statValue = 1;
        }

        PlayerPrefs.SetFloat(statsMap[stat], statValue);

        onValueChangedActionsMap[stat].Invoke(statValue);
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
        
        onValueChangedActionsMap[stat].Invoke(statValue);
    }
}
