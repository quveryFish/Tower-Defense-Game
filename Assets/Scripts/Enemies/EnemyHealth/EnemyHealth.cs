using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
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
