using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave 1", menuName = "Scriptable Objects/WaveScrObj")]
public class WaveSriptableObjScript : ScriptableObject
{
    public List<EnemyInWave> enemiesInWave = new List<EnemyInWave>();
/*
    public int smallEnemiesInWave;
    public int mediumEnemiesInWave;
    public int tankyEnemiesInWave;

    public float timeToSpawnSmall;
    public float timeToSpawnMedium;
    public float timeToSpawnTanky;
*/
    public int endWaveMoneyReward;
}

[Serializable]
public class EnemyInWave
{
    public GameObject enemyPrefab;
    public float timeToSpawn;
    public int enemyCount;
}
