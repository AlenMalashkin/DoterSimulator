using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsValueChanger : MonoBehaviour
{
    public event Action OnValuesChangedEvent;
    
    public void IncreaseStats(float hungryConsumption, float moodConsumption, float sleepyConsumption)
    {
        var hungryValue = PlayerPrefs.GetFloat("Hungry", 1f);
        var sleepyValue = PlayerPrefs.GetFloat("Sleepy", 1f);
        var moodValue = PlayerPrefs.GetFloat("Mood", 1f);

        hungryValue += hungryConsumption;
        sleepyValue += sleepyConsumption;
        moodValue += moodConsumption;

        if (hungryValue >= 1)
        {
            hungryValue = 1;
        }

        if (sleepyValue >= 1)
        {
            sleepyValue = 1;
        }

        if (moodValue >= 1)
        {
            moodValue = 1;
        }

        PlayerPrefs.SetFloat("Hungry", hungryValue);
        PlayerPrefs.SetFloat("Sleepy", sleepyValue);
        PlayerPrefs.SetFloat("Mood", moodValue);
        
        OnValuesChangedEvent?.Invoke();
    }

    public void DecreaseStats(float hungryConsumption, float moodConsumption, float sleepyConsumption)
    {
        var hungryValue = PlayerPrefs.GetFloat("Hungry", 1f);
        var sleepyValue = PlayerPrefs.GetFloat("Sleepy", 1f);
        var moodValue = PlayerPrefs.GetFloat("Mood", 1f);

        hungryValue -= hungryConsumption;
        sleepyValue -= sleepyConsumption;
        moodValue -= moodConsumption;

        if (hungryValue <= 0)
        {
            hungryValue = 0;
        }

        if (sleepyValue <= 0)
        {
            sleepyValue = 0;
        }

        if (moodValue <= 0)
        {
            moodValue = 0;
        }

        PlayerPrefs.SetFloat("Hungry", hungryValue);
        PlayerPrefs.SetFloat("Sleepy", sleepyValue);
        PlayerPrefs.SetFloat("Mood", moodValue);
        
        OnValuesChangedEvent?.Invoke();
    }
}
