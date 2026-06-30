using UnityEngine;

public class DeathObjBehaviour : MonoBehaviour
{
    private float destroyTime = 2f;

    private void Update()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
