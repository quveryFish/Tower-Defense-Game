using UnityEngine;

public class EnemiesSelfSpawn : MonoBehaviour
{
    [SerializeField] private GameObject childSpawner;
    [SerializeField] private int numberOfChildren;
    [SerializeField] private GameObject childObj;
    private EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = this.gameObject.GetComponent<EnemyHealth>();

    }
    private void OnDestroy()
    {
        if (enemyHealth.GetEnemyHealth() <= 0)
        {
            GameObject spawner = Instantiate(childSpawner, transform.position, Quaternion.identity);
            //Debug.Log("Spawner created");
            spawner.GetComponent<EnemyTempSpawner>().SetNumberOfChildren(numberOfChildren);
            spawner.GetComponent<EnemyTempSpawner>().SetChildrenPrefab(childObj);
            spawner.GetComponent<EnemyTempSpawner>().SetCheckpoints(gameObject.GetComponent<EnemyMovement>().GetCheckpoints());
            spawner.GetComponent<EnemyTempSpawner>().SetCurrentCheckpointIndex(gameObject.GetComponent<EnemyMovement>().GetCurrentCheckpointIndex());


        }
    }
}
