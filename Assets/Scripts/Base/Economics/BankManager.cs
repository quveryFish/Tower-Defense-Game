using UnityEngine;
using UnityEngine.UI;

public class BankManager : MonoBehaviour
{
    private static BankManager instance;
    [SerializeField] private Text moneyText;
    private int money = 100;

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }
    public void SubtractMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
        }
        UpdateMoneyText();
    }


    private void UpdateMoneyText()
    {
        moneyText.text = $"${money}";
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
