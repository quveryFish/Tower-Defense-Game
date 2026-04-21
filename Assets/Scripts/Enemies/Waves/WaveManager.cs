using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<WaveSriptableObjScript> waveSriptableObj;

    [SerializeField] private Text waveTimeText;
    private CreateEnemy createEnemy;
    private float timeBetweenWaves = 0;
    public int currentWave = 0;

    public int enemiesLast;
    [SerializeField] private int enemiesSmall;
    [SerializeField] private int enemiesMedium;
    [SerializeField] private int enemiesTanky;


    private bool isWaveStarted = false;
    private bool isWaveCompleted = false;

    int rnd;
    bool spawnEnabled = false;
    private void Start()
    {
        createEnemy = this.gameObject.GetComponent<CreateEnemy>();
    }

    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space) && GetIsWaveStarted() == false))
        {
            isWaveStarted = true;//Починаєм гру
            enemiesLast = waveSriptableObj[currentWave].enemiesLastInWave;
            enemiesSmall = waveSriptableObj[currentWave].smallEnemiesInWave;
            enemiesMedium = waveSriptableObj[currentWave].mediumEnemiesInWave;
            enemiesTanky = waveSriptableObj[currentWave].tankyEnemiesInWave;
            Debug.Log("Wave Started");
        }

        if (timeBetweenWaves > 0)
        {
            waveTimeText.text = $"Next wave in {timeBetweenWaves.ToString("F1")} seconds.";
        }
        else
        {
            waveTimeText.text = "";
        }

        if (isWaveStarted == true)
        {
            isWaveCompleted = false;
        }
        else if (isWaveStarted == false && isWaveCompleted == true)
        {
            timeBetweenWaves -= Time.deltaTime;
            if (timeBetweenWaves <= 0 && currentWave <= waveSriptableObj.Count)
            {
                isWaveStarted = true;
                enemiesLast = waveSriptableObj[currentWave].enemiesLastInWave;
                enemiesSmall = waveSriptableObj[currentWave].smallEnemiesInWave;
                enemiesMedium = waveSriptableObj[currentWave].mediumEnemiesInWave;
                enemiesTanky = waveSriptableObj[currentWave].tankyEnemiesInWave;
            }
        }


        if (enemiesLast <= 0 && isWaveStarted == true)
        {
            //End of wave
            if (currentWave <= waveSriptableObj.Count)
            {
                currentWave++;
                isWaveStarted = false;
                isWaveCompleted = true;
                timeBetweenWaves = 6.7f;
                //Debug.Log($"Wave {currentWave} completed. Next wave will start in {timeBetweenWaves} seconds.");

            }

        }
    }

    public GameObject SelectEnemy()
    {
        GameObject enemyToSpawn = null;
        if (spawnEnabled == false && (enemiesSmall > 0 || enemiesMedium > 0 || enemiesTanky > 0))
        {
            rnd = Random.Range(1, waveSriptableObj[currentWave].enemiesInWave.Count + 1);
            Debug.Log($"Random number generated: {rnd-1}");
            spawnEnabled = true;
        }

        if ((waveSriptableObj[currentWave].enemiesInWave[rnd - 1].GetComponent<EnemyHealth>().GetEnemyType() == EnemyType.Small)
            && enemiesSmall > 0 && spawnEnabled)
        {
            enemyToSpawn = waveSriptableObj[currentWave].enemiesInWave[rnd - 1];
            enemiesSmall--;
            enemiesLast--;
        }
        else if ((waveSriptableObj[currentWave].enemiesInWave[rnd - 1].GetComponent<EnemyHealth>().GetEnemyType() == EnemyType.Medium)
            && enemiesMedium > 0 && spawnEnabled)
        {
            enemyToSpawn = waveSriptableObj[currentWave].enemiesInWave[rnd - 1];
            enemiesMedium--;
            enemiesLast--;
        }
        else if ((waveSriptableObj[currentWave].enemiesInWave[rnd - 1].GetComponent<EnemyHealth>().GetEnemyType() == EnemyType.Tanky)
            && enemiesTanky > 0 && spawnEnabled)
        {
            enemyToSpawn = waveSriptableObj[currentWave].enemiesInWave[rnd - 1];
            enemiesTanky--;
            enemiesLast--;
        }
        else if (enemiesSmall <= 0 || enemiesMedium <= 0 || enemiesTanky <= 0)
        {
            spawnEnabled = false;
            enemyToSpawn = null;
        }


        return enemyToSpawn;
        //return waveSriptableObj[currentWave].enemiesInWave[rnd];
    }

    public bool GetIsWaveStarted()
    {
        return isWaveStarted;
    }
    public bool SetIsWaveStarted(bool isStarted)
    {
        return isWaveStarted = isStarted;
    }
    public int GetCurrentWave()
    {
        return currentWave;
    }
    public int GetAmountOfWaves()
    {
        return waveSriptableObj.Count;
    }
}
