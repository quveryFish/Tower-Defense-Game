using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public static CreateEnemy Instance;

    [SerializeField] private GameObject currentEnemyToSpawn;
    [SerializeField] private Transform enemyEntry;
    [SerializeField] private List<Transform> checkpoints;
    [SerializeField] private List<GameObject> enemiesRemainsAlive;

    private WaveManager waveManager;
    private GameObject enemySelected;

    private float timeToSpawn = 0.7f;
    private float spawnTimer;

    private void Start()
    {
        waveManager = this.gameObject.GetComponent<WaveManager>();
        spawnTimer = 0.7f;
    }
    private void Update()
    {
        if (waveManager.GetIsWaveStarted())//Починаєм автоматично спавнити ворогів
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {

                enemySelected = waveManager.SelectEnemy();
                if (enemySelected != null)
                    SpawnEnemy();
                //Debug.Log($"Enemies left to spawn: {waveManager.enemiesLast}");
                spawnTimer = timeToSpawn;
            }
        }

    }
    private void SpawnEnemy()
    {
        GameObject newObject;
        newObject = Instantiate(enemySelected, enemyEntry.position + new Vector3(0, -0.3f, 0), Quaternion.identity, this.gameObject.transform);
        enemiesRemainsAlive.Add(newObject);
        newObject.GetComponent<EnemyMovement>().SetCheckpoints(checkpoints);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemiesRemainsAlive.Contains(enemy))
        {
            enemiesRemainsAlive.Remove(enemy);
        }
    }
    public int GetEnemiesRemainsCount()
    {
        return enemiesRemainsAlive.Count;
    }
    public void SetTimer(float timeToSet)
    {
        timeToSpawn = timeToSet;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
