using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave 1", menuName = "Scriptable Objects/WaveScrObj")]
public class WaveSriptableObjScript : ScriptableObject
{
    public List<GameObject> enemiesInWave = new List<GameObject>();
    public int smallEnemiesInWave;
    public int mediumEnemiesInWave;
    public int tankyEnemiesInWave;
    public float timeToSpawnSmall;
    public float timeToSpawnMedium;
    public float timeToSpawnTanky;

}
