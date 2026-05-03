using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private float lifeTime = 2f;
    private int damage;
    private int penetration;

    bool isHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealth>() != null)
        {

            if (isHit) return;
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            isHit = true;
            if (isHit = true && penetration > 0)
            {
                penetration--;
                isHit = false;
                if (penetration <= 0)
                {
                    penetration = 0;
                    Destroy(gameObject);
                }
            }


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
    public void SetPenetration(int penetration)
    {
        this.penetration = penetration;
    }
    public void SetRotation(Transform rotation)
    {
        transform.rotation = rotation.rotation;
    }
}
