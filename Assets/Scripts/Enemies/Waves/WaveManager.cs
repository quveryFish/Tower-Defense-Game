using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject endUI;
    [SerializeField] private List<WaveSriptableObjScript> waveSriptableObj;
    [SerializeField] private Text waveTimeText;
    private float timeBetweenWaves;
    public int currentWave = 0;

    public int currentEnemiesLast;
    private int currentEnemy;

    private bool isWaveStarted = false;
    private bool isWaveCompleted = false;

    //int enemyTypeNum;
    //bool spawnEnabled = false;
    private void Start()
    {
        waveTimeText.text = "";
    }

    private void Update()
    {
        WaveFirstStart();

        //timer text between waves
        timeBetweenWaves -= Time.deltaTime;
        if (timeBetweenWaves > 0)
        {
            waveTimeText.text = $"Next wave in {timeBetweenWaves.ToString("F1")} seconds.";
        }
        else
        {
            waveTimeText.text = "";
        }

        EndOfWave();

        WaveSetup();
    }

    private void WaveFirstStart()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && GetIsWaveStarted() == false))
        {
            isWaveStarted = true;//Починаєм гру
            gameObject.GetComponent<TutorialScript>().DissableMessege();
            currentEnemiesLast = waveSriptableObj[currentWave].enemiesInWave[currentEnemy].enemyCount;
            Debug.Log($"Wave {currentWave} started.");
        }
    }
    private void EndOfWave()
    {
        if (currentEnemy == waveSriptableObj[currentWave].enemiesInWave.Count - 1
            && currentEnemiesLast <= 0
            && isWaveStarted == true
            && CreateEnemy.Instance.GetEnemiesRemainsAlive().Count == 0)
        {
            //End of wave

            if (currentWave < waveSriptableObj.Count - 1)
            {
                BankManager.Instance.AddMoney(waveSriptableObj[currentWave].endWaveMoneyReward);
                currentWave++;
                if (currentWave == 4 || currentWave == 7 || currentWave == 9)
                {
                    gameObject.GetComponent<TutorialScript>().ShowMessage();
                }
                isWaveStarted = false;
                isWaveCompleted = true;
                timeBetweenWaves = 6.7f;
                currentEnemy = 0;
                //Debug.Log($"Wave {currentWave} completed. Next wave will start in {timeBetweenWaves} seconds.");

            }
            else if (currentWave == waveSriptableObj.Count - 1
                && currentEnemiesLast <= 0
                && CreateEnemy.Instance.GetEnemiesRemainsAlive().Count == 0)
            {
                if (endUI.activeSelf == false)
                {
                    Debug.Log("All waves completed! You win!");
                    endUI.SetActive(true);
                }
            }
        }
    }
    private void WaveSetup()
    {
        //Check if wave is completed and start timer for next wave
        if (isWaveStarted == true)
        {
            isWaveCompleted = false;
        }
        else if (isWaveStarted == false && isWaveCompleted == true)
        {
            if (timeBetweenWaves <= 0 && currentWave <= waveSriptableObj.Count)
            {
                
                isWaveStarted = true;
                Debug.Log($"Wave {currentWave} started.");
                currentEnemiesLast = waveSriptableObj[currentWave].enemiesInWave[currentEnemy].enemyCount;
                //currentEnemy = 0;
            }
        }
    }

    public GameObject SelectEnemy()
    {
        GameObject selectedEn = null;
        if (currentEnemiesLast <= 0 && currentEnemy < waveSriptableObj[currentWave].enemiesInWave.Count - 1)
        {
            currentEnemy++;
            currentEnemiesLast = waveSriptableObj[currentWave].enemiesInWave[currentEnemy].enemyCount;
        }
        else
        {
            selectedEn = waveSriptableObj[currentWave].enemiesInWave[currentEnemy].enemyPrefab;
            
        }
        return selectedEn;
    }

    public float GetTimeToSpawnEnemy()
    {
        return waveSriptableObj[currentWave].enemiesInWave[currentEnemy].timeToSpawn;
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
