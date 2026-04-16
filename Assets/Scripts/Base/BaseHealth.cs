using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private Text healthText;
    private int health = 250;
    public void DealDamageToBase(int damage)
    {
        health -= damage;
        healthText.text = "HP: " + health.ToString();
        if (health <= 0)
        {
            healthText.text = "Destroyed";
        }
    }
}
