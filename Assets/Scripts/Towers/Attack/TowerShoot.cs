using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Transform attackDot;
    [Header("Stats")]
    private float attackCooldown = 1f;
    [SerializeField] private float attackMaxCooldown = 1f;
    [SerializeField] private float bulletSpeed = 50f;
    [SerializeField] private int damage = 1;

    private void Start()
    {
        attackCooldown = 0f;
    }

    private void Update()
    {
        if (gameObject.GetComponent<TowerRotateToEnemy>().IsEnemyInRange() && attackCooldown <=0)
        {
            Shoot();
        }
        attackCooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        attackCooldown = attackMaxCooldown;

        gameObject.GetComponent<TowerAnimations>().PlayAttackAnimation();//Animation

        GameObject bullet = Instantiate(bulletPref, attackDot.position, Quaternion.identity, this.gameObject.transform);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed * 100);
        if (bullet.GetComponent<ProjectileBehaviour>() != null)
        {
            bullet.GetComponent<ProjectileBehaviour>().SetDamage(damage);
        }
        else if (bullet.GetComponent<SlownessProjectileBehaviour>() != null)
        {
            bullet.GetComponent<SlownessProjectileBehaviour>().SetEnemy(gameObject.GetComponent<TowerRotateToEnemy>().GetFirstEnemy());
            bullet.GetComponent<SlownessProjectileBehaviour>().SetSpeed(bulletSpeed);
        }
    }

    public float GetAttackCooldown()
    {
        return attackCooldown;
    }
}
