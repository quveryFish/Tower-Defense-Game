using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject currentEnemyToSpawn;
    [SerializeField] private Transform enemyEntry;
    [SerializeField] private List<Transform> checkpoints;

    private WaveManager waveManager;
    private GameObject enemySelected;

    private float minTimeToSpawn = 0.3f;
    private float maxTimeToSpawn = 1f;
    private float spawnTimer;

    private void Start()
    {
        waveManager = this.gameObject.GetComponent<WaveManager>();
        spawnTimer = maxTimeToSpawn;
    }
    private void Update()
    {
        if (waveManager.GetIsWaveStarted() && waveManager.enemiesLast > 0)//Починаєм автоматично спавнити ворогів
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {

                enemySelected = waveManager.SelectEnemy();
                if (enemySelected != null)
                    SpawnEnemy();
                //Debug.Log($"Enemies left to spawn: {waveManager.enemiesLast}");
                spawnTimer = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            }
        }

    }
    private void SpawnEnemy()
    {
        GameObject newObject;
        newObject = Instantiate(enemySelected, enemyEntry.position + new Vector3(0, -0.3f, 0), Quaternion.identity, this.gameObject.transform);
        newObject.GetComponent<EnemyMovement>().SetCheckpoints(checkpoints);
    }


}
