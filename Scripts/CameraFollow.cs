using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // player's Transform
    public float smoothSpeed = 0.125f;  // the smoothness of the camera follow

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void LateUpdate()
    {
        if (target != null)
        {
            float clampedX = Mathf.Clamp(target.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(target.position.y, minY, maxY);

            Vector3 desiredPosition = new Vector3(clampedX, clampedY, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
