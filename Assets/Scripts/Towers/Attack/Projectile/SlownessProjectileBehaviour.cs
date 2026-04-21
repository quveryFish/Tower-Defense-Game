using UnityEngine;

public class SlownessProjectileBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private float lifeTime = 4f;
    private GameObject targetEnemy;

    private Vector3 direction;
    private float speed = 4f;

    private float slownessPercentage = 0.6f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //private int damage;

    bool isHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealth>() != null)
        {
            if (!isHit)
            {
                //other.GetComponent<EnemyHealth>().TakeDamage(damage);
                other.GetComponent<EnemyMovement>().SlowdownEnemy(slownessPercentage);
                Destroy(gameObject);
                isHit = true;
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

    private void FixedUpdate()
    {
        if (targetEnemy != null)
        {
            direction = (targetEnemy.transform.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }

    }

    public GameObject SetEnemy(GameObject firstenemy)
    {
        return targetEnemy = firstenemy;
    }

    public float SetSpeed(float newSpeed)
    {
        return speed = newSpeed;
    }
}
