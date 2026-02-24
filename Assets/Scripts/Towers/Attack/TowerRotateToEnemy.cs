using System.Threading;
using UnityEngine;

public class TowerRotateToEnemy : MonoBehaviour
{
    private float Range = 5f;
    //private float rotationSpeed = 5f;

    [SerializeField]   private GameObject firstEnemy;
    private bool firstEnemyInRange = false;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void Update()
    {
        FindFirstEnemy();
    }

    private void FindFirstEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Range);

        foreach (var hit in hitColliders)
        {
            if (hit.GetComponent<EnemyMovement>() != null && firstEnemy == null && firstEnemyInRange == false)
            {
                //Debug.Log("Enemy Detected");
                firstEnemy = hit.gameObject;
            }
            else if (firstEnemy != null)
            {
                if (gameObject.GetComponent<TowerShoot>().GetAttackCooldown() < 0.1f)
                {
                    transform.rotation = Quaternion.LookRotation(firstEnemy.transform.position - transform.position).normalized;
                    transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
                    firstEnemyInRange = true;
                    //Debug.Log("Enemy in Range");

                    if (firstEnemyInRange && Vector3.Distance(transform.position, firstEnemy.transform.position) > Range)
                    {

                        firstEnemy = null;
                    }
                }

            }
            if (firstEnemy == null)
            {
                firstEnemyInRange = false;
            }
        }
    }


    public bool IsEnemyInRange()
    {
        return firstEnemyInRange;
    }
}
