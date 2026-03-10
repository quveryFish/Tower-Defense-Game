using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private float lifeTime = 2f;
    private int damage;

    bool isHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealth>() != null)
        {

            if (isHit) return;
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
            isHit = true;
        }
    }
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
