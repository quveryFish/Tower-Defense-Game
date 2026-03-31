using System.Collections.Generic;
using UnityEngine;

public class EnemyTempSpawner : MonoBehaviour
{
    private GameObject tempchildrenPrefab;
    private int tempnumberOfChildren;
    private List<Transform> tempcheckpointsOnMap;
    private int tempcurrentCheckpointIndex;


    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnChildren();
            spawnTimer = 0.5f;
        }
        
    }

    private void SpawnChildren()
    {
        for (int i = 0; i <= tempnumberOfChildren - 1; i++)
        {
            GameObject childEn = Instantiate(tempchildrenPrefab, transform.position, Quaternion.identity);
            childEn.GetComponent<EnemyMovement>().SetCheckpoints(tempcheckpointsOnMap);//Список чекпоінтів

            childEn.GetComponent<EnemyMovement>().SetCurrentCheckpointIndex(tempcurrentCheckpointIndex); //Індекс поточного чекпоінта
            if (i == tempnumberOfChildren - 1)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetNumberOfChildren(int number)
    {
        tempnumberOfChildren = number;
    }
    public void SetChildrenPrefab(GameObject prefab)
    {
        tempchildrenPrefab = prefab;
    }
    public void SetCheckpoints(List<Transform> checkpoints)
    {
        tempcheckpointsOnMap = checkpoints;
    }
    public void SetCurrentCheckpointIndex(int index)
    {
        tempcurrentCheckpointIndex = index;
    }
}
