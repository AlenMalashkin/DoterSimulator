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
        _continueButton.onClick.AddListener(Continue);
    }

    private void OnDisable()
    {
        _retryButton.onClick.RemoveListener(Retry);
        _continueButton.onClick.RemoveListener(Continue);
    }

    private void Retry()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main");
    }

    private void Continue()
    {
        PlayerPrefs.SetFloat("Hungry", 1);
        PlayerPrefs.SetFloat("Mood", 1);
        PlayerPrefs.SetFloat("Sleepy", 1);
        SceneManager.LoadScene("Main");
    }
}
