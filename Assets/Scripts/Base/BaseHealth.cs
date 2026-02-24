using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private TextMesh healthText;
    private int health = 250;
    public void DealDamageToBase(int damage)
    {
        health -= damage;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            healthText.text = "Destroyed";
        }
    }
}
