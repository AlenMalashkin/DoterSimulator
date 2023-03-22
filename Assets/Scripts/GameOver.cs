using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Notification _alert;
    private StatsValueChanger _statsValueChanger;

    private int _stepsToDieFormHungry = 5;
    private int _stepsToDieFormSleepy = 5;
    private int _stepsToDieFormMood = 5;

    private Dictionary<Stats, string> _messagesMap;

    public void Init(Notification alert, StatsValueChanger statsValueChanger)
    {
        _alert = alert;
        _statsValueChanger = statsValueChanger;
        
        _messagesMap = new Dictionary<Stats, string>()
        {
            {Stats.Hungry, $"Вы слишком голодны! улучшите свои показатели в течении следующих {_stepsToDieFormHungry} ходов или умрете с голоду!"},
            {Stats.Mood, $"У вас слишком плохое настроение! улучшите свои показатели в течении следующих {_stepsToDieFormMood} ходов или вас замучает депрессия!"},
            {Stats.Sleepy, $"Вы слишком сонный! улучшите свои показатели в течении следующих {_stepsToDieFormSleepy} ходов или умрете от недосыпа!"}
        };

        _statsValueChanger.OnHungryValueChangedEvent += OnHungryValueChanged;
        _statsValueChanger.OnMoodValueChangedEvent += OnMoodValueChanged;
        _statsValueChanger.OnSleepyValueChangedEvent += OnSleepyValueChanged;
    }

    private void OnDisable()
    {
        _statsValueChanger.OnHungryValueChangedEvent -= OnHungryValueChanged;
        _statsValueChanger.OnMoodValueChangedEvent -= OnMoodValueChanged;
        _statsValueChanger.OnSleepyValueChangedEvent -= OnSleepyValueChanged;
    }

    private void OnHungryValueChanged(float value)
    {
        if (value <= 0)
        {
            _stepsToDieFormHungry -= 1;
            _alert.ShowMessage($"Вы слишком голодны! улучшите свои показатели в течении следующих {_stepsToDieFormHungry} ходов или умрете с голоду!");
        }
        else
        {
            _stepsToDieFormHungry = 5;
        }

        if (_stepsToDieFormHungry <= 0)
        {
            Die();
        }
    }

    private void OnSleepyValueChanged(float value)
    {
        if (value <= 0)
        {
            _stepsToDieFormSleepy -= 1;
            _alert.ShowMessage($"Вы слишком сонный! улучшите свои показатели в течении следующих {_stepsToDieFormSleepy} ходов или умрете от недосыпа!");
        }
        else
        {
            _stepsToDieFormSleepy = 5;
        }

        if (_stepsToDieFormSleepy <= 0)
        {
            Die();
        }
    }

    private void OnMoodValueChanged(float value)
    {
        if (value <= 0)
        {
            _stepsToDieFormMood -= 1;
            _alert.ShowMessage($"У вас слишком плохое настроение! улучшите свои показатели в течении следующих {_stepsToDieFormMood} ходов или вас замучает депрессия!");
        }
        else
        {
            _stepsToDieFormMood = 5;
        }

        if (_stepsToDieFormMood <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You're died!");
    }
}
