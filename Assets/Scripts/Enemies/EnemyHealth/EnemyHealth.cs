using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 10;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
