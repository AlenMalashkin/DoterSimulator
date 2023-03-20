using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SpendMoney : MonoBehaviour
{
	[SerializeField] private int spendAmount;
	
	private Button _button;
	
	private void OnEnable()
	{
		_button = GetComponent<Button>();

		Bank.Instance.OnMoneyValueChanged += EnableButton;
		Bank.Instance.OnMoneyValueChanged += DisableButton;
		
		_button.onClick.AddListener(() => Bank.Instance.SpendMoney(spendAmount));
		
		DisableButton(PlayerPrefs.GetInt("Money"));
		EnableButton(PlayerPrefs.GetInt("Money"));
	}

	private void OnDisable()
	{
		Bank.Instance.OnMoneyValueChanged -= EnableButton;
		Bank.Instance.OnMoneyValueChanged -= DisableButton;
	}

	private void EnableButton(int money)
	{
		if (money >= spendAmount)
			_button.interactable = true;
	}

	private void DisableButton(int money)
	{
		if (money < spendAmount)
			_button.interactable = false;
	}
}
