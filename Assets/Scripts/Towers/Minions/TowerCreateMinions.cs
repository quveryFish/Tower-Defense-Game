using System.Collections.Generic;
using UnityEngine;

public class TowerCreateMinions : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private float timeToCreateMinion = 30f;
    [SerializeField] private int minionHealth = 20;

    private List<Transform> checkpointsOnMap;
    private float timer;

    private void Start()
    {
        timer = timeToCreateMinion / 5 ;
        checkpointsOnMap = CreateEnemy.Instance.GetCheckpoints();
    }
    private void Update()
    {
        if (CreateEnemy.Instance.gameObject.GetComponent<WaveManager>().GetIsWaveStarted() == false)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            CreateMinion();
            timer = timeToCreateMinion;
        }
    }

    private void CreateMinion()
    {
        if (minionPrefab != null)
        {
            GameObject minion = Instantiate(minionPrefab, checkpointsOnMap[checkpointsOnMap.Count -1].position
                , Quaternion.identity);

            TWMinionsMovement minionMovement = minion.GetComponent<TWMinionsMovement>();
            if (minionMovement != null)
            {
                minionMovement.SetCheckpoints(checkpointsOnMap);
                minionMovement.SetMoveSpeed(moveSpeed);
                minion.GetComponent<TW_MinionsHealth>().SetMinionHealth(minionHealth); // Set the health of the minion
            }
        }
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void SetSpawnSpeed(float time)
    {
        timeToCreateMinion = time;
    }
    public void SetSpawnHealth(int amount)
    {
        minionHealth = amount;
    }
}
