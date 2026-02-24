using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private List<Transform> checkpointsOnMap;
    private Rigidbody rb;

    private int currentCheckpointIndex = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = (checkpointsOnMap[currentCheckpointIndex].position - transform.position).normalized * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpointIndex++;
        }
    }
    public List<Transform> SetCheckpoints(List<Transform> checkPoints)
    {
        checkpointsOnMap = checkPoints;
        return checkpointsOnMap;
    }


}
