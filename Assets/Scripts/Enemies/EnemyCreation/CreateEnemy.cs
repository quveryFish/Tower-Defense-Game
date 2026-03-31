using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject currentEnemyToSpawn;
    [SerializeField] private Transform enemyEntry;
    [SerializeField] private List<Transform> checkpoints;
    [SerializeField] private List<WaveSriptableObjScript> waveSriptableObj;

    public int currentWave = 0;

    public float timeBetweenWaves = 5;

    private bool isWaveStarted = false;
    private int enemiesLast;

    private float minTimeToSpawn = 0.7f;
    private float maxTimeToSpawn = 3f;
    private float spawnTimer;

    private void Start()
    {
        spawnTimer = maxTimeToSpawn;
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && isWaveStarted == false) || ( timeBetweenWaves <= 0 && isWaveStarted == false))
        {
            isWaveStarted = true;
            enemiesLast = waveSriptableObj[currentWave].enemiesLastInWave;
            Debug.Log("Wave Started");
        }
        if ( isWaveStarted && enemiesLast > 0)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                SpawnEnemy();
                enemiesLast--;
                Debug.Log($"Enemies left to spawn: {enemiesLast}");
                spawnTimer = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            }
        }

    }
    private void SpawnEnemy()
    {
        SelectEnemy();
        GameObject newObject;
        newObject = Instantiate(currentEnemyToSpawn, enemyEntry.position, Quaternion.identity, this.gameObject.transform);
        newObject.GetComponent<EnemyMovement>().SetCheckpoints(checkpoints);
    }

    private void SelectEnemy()
    {
        int rnd = Random.Range(0, waveSriptableObj[currentWave].enemiesInWave.Count);
        currentEnemyToSpawn = waveSriptableObj[currentWave].enemiesInWave[rnd];
    }

    public int GetEnemiesLast()
    {
        return enemiesLast;
    }
    public bool GetIsWaveStarted()
    {
        return isWaveStarted;
    }
    public bool SetIsWaveStarted(bool isStarted)
    {
        return isWaveStarted = isStarted;
    }
    public int GetAmountOfWaves()
    {
        return waveSriptableObj.Count;
    }
}
