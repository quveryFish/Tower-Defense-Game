using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private int moneyValue = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            BankManager.Instance.AddMoney(moneyValue);
            Destroy(gameObject);
        }
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
    }
    public int GetEnemyHealth()
    {
        return health;
    }
}
