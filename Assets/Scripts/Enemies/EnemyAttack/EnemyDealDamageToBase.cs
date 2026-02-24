using UnityEngine;

public class EnemyDealDamageToBase : MonoBehaviour
{
    [SerializeField] private int damageAmount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseHealth>() != null)
        {
            Debug.Log("Found base");
            other.GetComponent<BaseHealth>().DealDamageToBase(damageAmount);
            Destroy(gameObject);
        }
    }
}
