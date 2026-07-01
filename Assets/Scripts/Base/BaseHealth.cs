using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private int health = 100;
    private int maxHealth = 250;
    private void Start()
    {
        healthText.text = "HP: " + health.ToString();
        maxHealth = health;
    }
    public void DealDamageToBase(int damage)
    {
        health -= damage;
        healthText.text = "HP: " + health.ToString();
        healthBarFill.fillAmount = (float)health / maxHealth;
        if (health <= 0)
        {
            healthText.text = "Destroyed";
        }
    }
}
