using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float sensitivity = 200f;
    private float distance = 40f;

    

    private float yaw = 0f;
    private float pitch = 0f;
    private void Start()
    {
        pitch = 45f;
    }
    private void Update()
    {
        HandleInput();

        Quaternion yawRotation = Quaternion.Euler(pitch, yaw, 0f);

        RotateCamera(yawRotation);
    }

    private void HandleInput()
    {
        Vector2 inputDelta = Vector2.zero;
        if (Input.GetMouseButton(2))
        {
            inputDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
            yaw += inputDelta.x;
            pitch -= inputDelta.y;
            pitch = Mathf.Clamp(pitch, 0f, 75f);
        }
    }
    private void RotateCamera(Quaternion rotation)
    {
        Vector3 positionOffset = rotation * new Vector3(0f, 0f, -distance);
        transform.position = target.position + positionOffset;
        transform.rotation = rotation;
    }
}
