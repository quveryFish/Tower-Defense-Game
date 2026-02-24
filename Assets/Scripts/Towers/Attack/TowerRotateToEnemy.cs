using System.Threading;
using UnityEngine;

public class TowerRotateToEnemy : MonoBehaviour
{
    private float Range = 5f;
    //private float rotationSpeed = 5f;

    private GameObject firstEnemy;
    private bool firstEnemyInRange = false;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Range);

        foreach (var hit in hitColliders)
        {
            if (hit.GetComponent<EnemyMovement>() != null && firstEnemy == null)
            {
                Debug.Log("Enemy Detected");
                firstEnemy = hit.gameObject;
            }
            else if (firstEnemy != null)
            {
                transform.rotation = Quaternion.LookRotation(firstEnemy.transform.position - transform.position).normalized;
                firstEnemyInRange = true;
            }

            if (firstEnemyInRange && Vector3.Distance(transform.position, firstEnemy.transform.position) > Range)
                {
                    firstEnemy = null;
                    firstEnemyInRange = false;
            }
        }
    }
}
