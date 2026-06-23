using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private int moneyValue = 5;
    [SerializeField] private bool isHiden = false;

    private SkinnedMeshRenderer[] renderers;

    private float redTimer = 0.1f;
    private float timer;
    private void Start()
    {
        renderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        timer = redTimer;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            foreach (SkinnedMeshRenderer r in renderers)
            {
                r.material.color = Color.white;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        foreach (SkinnedMeshRenderer r in renderers)
        {
            r.material.color = Color.orange;
        }
        timer = redTimer;
        
        
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
    public bool GetIsHiden()
    {
        return isHiden;
    }
}
