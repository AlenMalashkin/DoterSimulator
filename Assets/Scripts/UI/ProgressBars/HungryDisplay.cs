using System;
using UnityEngine;
using UnityEngine.UI;

public class HungryDisplay : MonoBehaviour, IProgressBarObserver
{
    [SerializeField] private Image hungerImage;
    [SerializeField] private Text hungerText;

    private void OnEnable()
    {
        UpdateValue();
    }

    public void OnValueChanged()
    {
        UpdateValue();
    }

    private void UpdateValue()
    {
        var value = PlayerPrefs.GetFloat("Hungry", 1f);

        hungerImage.fillAmount = value;
        hungerText.text = Mathf.RoundToInt(value * 100f) + "%";
    }
}
