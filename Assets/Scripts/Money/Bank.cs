using System;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public event Action<int> OnMoneyValueChanged;
    
    private static Bank _instance;
    public static Bank Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpendMoney(int amount)
    {
        var money = PlayerPrefs.GetInt("Money", 0);

        if (money >= amount)
        {
            money -= amount;
            PlayerPrefs.SetInt("Money", money);
        }
        
        OnMoneyValueChanged?.Invoke(money);
    }

    public void GetMoney(int amount)
    {
        var money = PlayerPrefs.GetInt("Money", 0);
        money += amount;
        PlayerPrefs.SetInt("Money", money);
        
        OnMoneyValueChanged?.Invoke(money);
    }
}
