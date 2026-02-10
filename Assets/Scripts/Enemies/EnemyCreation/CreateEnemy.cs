using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemyEntry;
    [SerializeField] private List<Transform> checkpoints;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newObject;
            newObject = Instantiate(enemyPrefab, enemyEntry.position, Quaternion.identity);
            newObject.GetComponent<EnemyMovement>().SetCheckpoints(checkpoints);
        }
    }
}
