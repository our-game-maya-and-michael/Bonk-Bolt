using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // Player's transform
    public float distanceFromPlayer = 10.0f; // Distance between the camera and the player
    public float currentX = 0.0f; // Current X rotation
    public float currentY = 0.0f; // Current Y rotation
    public float sensitivityX = 4.0f; // Sensitivity of mouse movement in X direction
    public float sensitivityY = 1.0f; // Sensitivity of mouse movement in Y direction

    private const float Y_ANGLE_MIN = -50.0f; // Minimum Y angle to prevent flipping
    private const float Y_ANGLE_MAX = 50.0f; // Maximum Y angle to prevent flipping

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distanceFromPlayer);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = playerTransform.position + rotation * dir;
        transform.LookAt(playerTransform.position);
    }
}
