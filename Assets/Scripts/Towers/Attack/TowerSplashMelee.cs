using UnityEngine;

public class TowerSplashMelee : MonoBehaviour
{
    [Header("Stats")]
    private float attackCooldown = 1f;
    [SerializeField] private float attackMaxCooldown = 1f;
    [SerializeField] private int damage = 2;

    private float attackRange;

    private void Start()
    {
        attackCooldown = 0f;
        attackRange = gameObject.GetComponent<TowerRotateToEnemy>().GetRange();
    }

    private void Update()
    {
        if (gameObject.GetComponent<TowerRotateToEnemy>().IsEnemyInRange() && attackCooldown <= 0)
        {
            Attack();
        }
        attackCooldown -= Time.deltaTime;
    }


    private void Attack()
    {
        attackCooldown = attackMaxCooldown;

        gameObject.GetComponent<TowerAnimations>().PlayAttackAnimation();

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (var hit in hitColliders)
        {
            if (hit.GetComponent<EnemyMovement>() != null)
            {
                hit.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
    }

    public float GetAttackCooldown()
    {
        return attackCooldown;
    }


}
