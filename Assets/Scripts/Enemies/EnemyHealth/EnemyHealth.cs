using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private int moneyValue = 5;
    [SerializeField] private EnemyType enemyType;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            BankManager.Instance.AddMoney(moneyValue);
            CreateEnemy.Instance.RemoveEnemy(gameObject);
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

    public EnemyType GetEnemyType()
    {
        return enemyType;
    }
}
public enum EnemyType
{
    Small,
    Medium,
    Tanky
}
