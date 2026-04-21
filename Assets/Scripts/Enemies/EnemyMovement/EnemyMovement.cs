using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private float originalMoveSpeed;
    private List<Transform> checkpointsOnMap;
    private Rigidbody rb;

    private int currentCheckpointIndex = 0;

    private float timeForSlowdownEffect = 4f;
    private float slowdownTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalMoveSpeed = moveSpeed;
    }
    private void FixedUpdate()
    {
        transform.LookAt(checkpointsOnMap[currentCheckpointIndex].position + new Vector3(0, -0.5f, 0));
        rb.linearVelocity = ((checkpointsOnMap[currentCheckpointIndex].position + new Vector3(0, -0.5f, 0)) - transform.position).normalized * moveSpeed;

    }

    private void Update()
    {
        if (slowdownTimer > 0)
        {
            slowdownTimer -= Time.deltaTime;
            if (slowdownTimer <= 0)
            {
                moveSpeed = originalMoveSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpointIndex++;
        }
    }

    public void SlowdownEnemy(float speedPercentage)
    {
        moveSpeed = originalMoveSpeed * speedPercentage;
        slowdownTimer = timeForSlowdownEffect;
    }

    public List<Transform> SetCheckpoints(List<Transform> checkPoints)
    {
        checkpointsOnMap = checkPoints;
        return checkpointsOnMap;
    }
    public List<Transform> GetCheckpoints()
    {
        return checkpointsOnMap;
    }
    public int GetCurrentCheckpointIndex()
    {
        return currentCheckpointIndex;
    }
    public int SetCurrentCheckpointIndex(int index)
    {
        currentCheckpointIndex = index;
        return currentCheckpointIndex;
    }
}
