using System;
using UnityEngine;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
    [SerializeField] private GameObject alert;
    [SerializeField] private Text alertText;
    [SerializeField] private Button closeButton;

    private void OnEnable()
    {
        closeButton.onClick.AddListener(CloseAlert);
    }

    private void OnDisable()
    {
        closeButton.onClick.RemoveListener(CloseAlert);
    }

    private void Start()
    {
        alert.SetActive(false);
    }

    private void CloseAlert()
    {
        alert.SetActive(false);
    }
    
    public void ShowAlert(string message)
    {
        alertText.text = message;
        alert.SetActive(true);
    }
}
