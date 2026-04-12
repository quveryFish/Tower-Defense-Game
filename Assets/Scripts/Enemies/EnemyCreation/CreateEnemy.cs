using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject currentEnemyToSpawn;
    [SerializeField] private Transform enemyEntry;
    [SerializeField] private List<Transform> checkpoints;

    private WaveManager waveManager;

    private float minTimeToSpawn = 0.7f;
    private float maxTimeToSpawn = 3f;
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
                SpawnEnemy();
                waveManager.enemiesLast--;
                //Debug.Log($"Enemies left to spawn: {waveManager.enemiesLast}");
                spawnTimer = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            }
        }

    }
    private void SpawnEnemy()
    {

        GameObject newObject;
        newObject = Instantiate(waveManager.SelectEnemy(), enemyEntry.position, Quaternion.identity, this.gameObject.transform);
        newObject.GetComponent<EnemyMovement>().SetCheckpoints(checkpoints);
    }


}
