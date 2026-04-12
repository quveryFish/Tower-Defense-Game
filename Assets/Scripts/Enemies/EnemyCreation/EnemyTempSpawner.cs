using System.Collections.Generic;
using UnityEngine;

public class EnemyTempSpawner : MonoBehaviour
{
    private GameObject tempchildrenPrefab;
    private int tempnumberOfChildren;
    private List<Transform> tempcheckpointsOnMap;
    private int tempcurrentCheckpointIndex;
    int i;

    private float spawnTimer = 0f;

    private void Start()
    {
        i = 0;
    }
    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnChildren();
            //Debug.Log("children spawned");
        }
        
    }

    private void SpawnChildren()
    {

        if (i <= tempnumberOfChildren)
        {
            i++;
            GameObject childEn = Instantiate(tempchildrenPrefab, transform.position, Quaternion.identity);
            childEn.GetComponent<EnemyMovement>().SetCheckpoints(tempcheckpointsOnMap);//Список чекпоінтів

            childEn.GetComponent<EnemyMovement>().SetCurrentCheckpointIndex(tempcurrentCheckpointIndex); //Індекс поточного чекпоінта
            spawnTimer = 0.2f;
            if (i == tempnumberOfChildren)
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
