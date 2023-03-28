using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieScreen : MonoBehaviour
{
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _continueButton;

    private void OnEnable()
    {
        _retryButton.onClick.AddListener(Retry);
    }

    private void OnDisable()
    {
        _retryButton.onClick.RemoveListener(Retry);
    }

    private void Retry()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main");
    }
}
