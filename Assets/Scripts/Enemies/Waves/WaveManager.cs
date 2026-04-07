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

    private bool isWaveStarted = false;
    private bool isWaveCompleted = false;
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
            Debug.Log($"Next wave will start in {timeBetweenWaves} seconds.");
            timeBetweenWaves -= Time.deltaTime;
            if (timeBetweenWaves <= 0)
            {
                isWaveStarted = true;
                enemiesLast = waveSriptableObj[currentWave].enemiesLastInWave;
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
                Debug.Log($"Wave {currentWave} completed. Next wave will start in {timeBetweenWaves} seconds.");

            }

        }
    }

    public GameObject SelectEnemy()
    {
        int rnd = Random.Range(0, waveSriptableObj[currentWave].enemiesInWave.Count);
        return waveSriptableObj[currentWave].enemiesInWave[rnd];
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
