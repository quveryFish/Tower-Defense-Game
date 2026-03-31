using UnityEngine;
using UnityEngine.UI;

public class BankManager : MonoBehaviour
{
    public static BankManager Instance;
    [SerializeField] private Text moneyText;
    private int money = 100;
    private bool canPlaceTower = true;


    private void Start()
    {
        UpdateMoneyText();
    }

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
        else
        {
            Debug.Log("Not enough money!");
            canPlaceTower = false;
        }
        UpdateMoneyText();
    }

    public void CheckIsEnough(int amount)
    {
        if (money >= amount)
        {
            canPlaceTower = true;
        }
        else
        {
            canPlaceTower = false;
        }
    }

    public bool CanAfford()
    {
        return canPlaceTower;
    }


    private void UpdateMoneyText()
    {
        moneyText.text = $"${money}";
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
