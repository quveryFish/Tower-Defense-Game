using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<WaveSriptableObjScript> waveSriptableObj;

    [SerializeField] private Text waveTimeText;
    //private CreateEnemy createEnemy;
    private float timeBetweenWaves = 0;
    public int currentWave = 0;

    //public int enemiesLast;
    [SerializeField] private int enemiesSmall;
    [SerializeField] private int enemiesMedium;
    [SerializeField] private int enemiesTanky;
    private bool noEnemiesLeftToSpawn = false;


    private bool isWaveStarted = false;
    private bool isWaveCompleted = false;

    int enemyTypeNum;
    bool spawnEnabled = false;
    private void Start()
    {
        waveTimeText.text = "";
    }

    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space) && GetIsWaveStarted() == false))
        {
            isWaveStarted = true;//Починаєм гру
            enemiesSmall = waveSriptableObj[currentWave].smallEnemiesInWave;
            enemiesMedium = waveSriptableObj[currentWave].mediumEnemiesInWave;
            enemiesTanky = waveSriptableObj[currentWave].tankyEnemiesInWave;
            noEnemiesLeftToSpawn = false;
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
                enemiesSmall = waveSriptableObj[currentWave].smallEnemiesInWave;
                enemiesMedium = waveSriptableObj[currentWave].mediumEnemiesInWave;
                enemiesTanky = waveSriptableObj[currentWave].tankyEnemiesInWave;
            }
        }


        if ((enemiesSmall <= 0 && enemiesMedium <= 0 && enemiesTanky <= 0)
            && CreateEnemy.Instance.GetEnemiesRemainsCount() <= 0 
            && isWaveStarted == true)
        {
            //End of wave
            if (currentWave <= waveSriptableObj.Count)
            {
                if (currentWave < waveSriptableObj.Count)
                {
                    currentWave++;
                }
                else
                {
                    Debug.Log("All waves completed! You win!");
                }
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
        if (spawnEnabled == false && (enemiesSmall > 0 || enemiesMedium > 0 || enemiesTanky > 0) && !noEnemiesLeftToSpawn)
        {
            if (enemiesSmall > 0)
            {
                enemyTypeNum = 0;
                CreateEnemy.Instance.SetTimer(waveSriptableObj[currentWave].timeToSpawnSmall);

            }
            else if (enemiesMedium > 0)
            {
                enemyTypeNum = 1;
                CreateEnemy.Instance.SetTimer(waveSriptableObj[currentWave].timeToSpawnMedium);
            }
            else if (enemiesTanky > 0)
            {
                enemyTypeNum = 2;
                CreateEnemy.Instance.SetTimer(waveSriptableObj[currentWave].timeToSpawnTanky);
            }
            spawnEnabled = true;
        }

        if ( enemyTypeNum == 0 && enemiesSmall > 0 && spawnEnabled)
        {
            enemyToSpawn = waveSriptableObj[currentWave].enemiesInWave[enemyTypeNum];
            enemiesSmall--;
        }
        else if ( enemyTypeNum == 1 && enemiesMedium > 0 && spawnEnabled)
        {
            enemyToSpawn = waveSriptableObj[currentWave].enemiesInWave[enemyTypeNum];
            enemiesMedium--;
        }
        else if (enemyTypeNum == 2 && enemiesTanky > 0 && spawnEnabled)
        {
            enemyToSpawn = waveSriptableObj[currentWave].enemiesInWave[enemyTypeNum];
            enemiesTanky--;
        }
        else if (enemiesSmall <= 0 || enemiesMedium <= 0 || enemiesTanky <= 0)
        {
            enemyToSpawn = null;
            spawnEnabled = false;
        }
        else if (enemiesSmall <= 0 && enemiesMedium <= 0 && enemiesTanky <= 0)
        {
            noEnemiesLeftToSpawn = true;
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
    public bool isNoEnemiesLeftToSpawn()
    {
        return noEnemiesLeftToSpawn;
    }
}
