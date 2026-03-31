using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private CreateEnemy createEnemy;

    private void Start()
    {
        createEnemy = this.gameObject.GetComponent<CreateEnemy>();
    }

    private void Update()
    {
        if (createEnemy.GetEnemiesLast() <= 0 && createEnemy.GetIsWaveStarted() == true)
        {
            //End of wave
            if (createEnemy.currentWave <= createEnemy.GetAmountOfWaves())
            {
                createEnemy.timeBetweenWaves = 5f;
                createEnemy.currentWave++;
                createEnemy.SetIsWaveStarted(false);

            }

        }
    }
}
