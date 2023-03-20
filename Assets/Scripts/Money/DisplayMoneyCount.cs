using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayMoneyCount : MonoBehaviour
{
    [SerializeField] private Text text;

    private void OnEnable()
    {
        DisplayCountOfMoney(PlayerPrefs.GetInt("Money", 0));

        Bank.Instance.OnMoneyValueChanged += DisplayCountOfMoney;
    }

    private void OnDisable()
    {
        Bank.Instance.OnMoneyValueChanged -= DisplayCountOfMoney;
    }

    private void DisplayCountOfMoney(int money)
    {
        text.text = money + "";
    }
}
