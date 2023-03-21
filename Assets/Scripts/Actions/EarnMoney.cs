using UnityEngine;
using UnityEngine.UI;

public class EarnMoney : MonoBehaviour, IRatingObserver
{
	[SerializeField] private int earnAmount;
	[SerializeField] private int ratingAmountToUnlockThisWork;
	
	private Button _button;
	
	private void OnEnable()
	{
		_button = GetComponent<Button>();
		
		_button.onClick.AddListener(() => Bank.Instance.GetMoney(earnAmount));

		_button.interactable = false;
		
		CheckRatingAmount(PlayerPrefs.GetInt("Rating"));
	}

	private void CheckRatingAmount(int rating)
	{
		if (rating >= ratingAmountToUnlockThisWork)
		{
			_button.interactable = true;
		}
	}

	public void OnRatingChanged(int rating)
	{
		CheckRatingAmount(rating);
	}
}
