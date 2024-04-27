using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float distanceFromTarget = 10f; // Удаленность камеры от персонажа

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position - transform.forward * distanceFromTarget;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}