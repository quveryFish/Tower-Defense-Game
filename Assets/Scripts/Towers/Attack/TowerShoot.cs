using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Transform attackPoint;
    [Header("Stats")]
    private float attackCooldown = 1f;
    [SerializeField] private float attackMaxCooldown = 1f;
    [SerializeField] private float bulletSpeed = 7f;
    [SerializeField] private int damage = 1;
    [SerializeField] private int penetration = 1;

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

        gameObject.GetComponent<PlaySound>().PlaySpecificSound();//Sound

        gameObject.GetComponent<TowerAnimations>().PlayAttackAnimation();//Animation

        GameObject bullet = Instantiate(bulletPref, attackPoint.position, Quaternion.identity, this.gameObject.transform);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed * 100);
        if (bullet.GetComponent<ProjectileBehaviour>() != null)
        {
            bullet.GetComponent<ProjectileBehaviour>().SetDamage(damage);
            bullet.GetComponent<ProjectileBehaviour>().SetPenetration(penetration);
            bullet.GetComponent<ProjectileBehaviour>().SetRotation(attackPoint);
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
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
    public void SetAttackCooldown(float newCooldown)
    {
        attackMaxCooldown = newCooldown;
    }
    public void SetProjSpeed(float newSpeed)
    {
        bulletSpeed = newSpeed;
    }
    public void SetPenetration(int newPen)
    {
        penetration = newPen;
    }
}
