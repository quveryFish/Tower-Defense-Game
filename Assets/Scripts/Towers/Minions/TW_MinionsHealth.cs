using UnityEngine;

public class TW_MinionsHealth : MonoBehaviour
{
    [SerializeField] private int minionHealth = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Entry")
        {
            Destroy(gameObject);
        }
        DealDamage(other.gameObject);
    }

    public void TakeDamage(int damage)
    {
        minionHealth -= damage;
        if (minionHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DealDamage(GameObject enemy)
    {
        if (enemy.GetComponent<EnemyHealth>() != null)
        {
            int damageToMinion = enemy.GetComponent<EnemyHealth>().GetEnemyHealth();
            enemy.GetComponent<EnemyHealth>().TakeDamage(minionHealth);
            TakeDamage(damageToMinion);


        }
    }

    public void SetMinionHealth(int health)
    {
        minionHealth = health;
    }
}
