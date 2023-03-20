using UnityEngine;
using UnityEngine.UI;

public class EarnMoney : MonoBehaviour
{
	[SerializeField] private int earnAmount;
	
	private Button _button;
	
	private void OnEnable()
	{
		_button = GetComponent<Button>();
		
		_button.onClick.AddListener(() => Bank.Instance.GetMoney(earnAmount));
	}
}
