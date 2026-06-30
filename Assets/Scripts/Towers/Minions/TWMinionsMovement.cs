using System.Collections.Generic;
using UnityEngine;

public class TWMinionsMovement : MonoBehaviour
{
    private float moveSpeed = 2f;
    private float distance = 0.6f;

    private Rigidbody rb;
    private List<Transform> checkpointsOnMap;
    private int currentCheckpointIndex = 0;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        currentCheckpointIndex = checkpointsOnMap.Count - 1;
    }
    private void FixedUpdate()
    {
        transform.LookAt(checkpointsOnMap[currentCheckpointIndex].position + new Vector3(0, -0.5f, 0));
        rb.linearVelocity = ((checkpointsOnMap[currentCheckpointIndex].position + new Vector3(0, -0.5f, 0)) - transform.position).normalized * moveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, checkpointsOnMap[currentCheckpointIndex].position);
        if (distanceToTarget <= distance)
        {
            //Debug.Log("Reached checkpoint: " + currentCheckpointIndex);
            currentCheckpointIndex--;
        }

    }
    public List<Transform> SetCheckpoints(List<Transform> checkPoints)
    {
        checkpointsOnMap = checkPoints;
        return checkpointsOnMap;
    }
    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
