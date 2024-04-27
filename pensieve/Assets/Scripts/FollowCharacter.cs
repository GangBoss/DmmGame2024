using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public Transform target; // Ссылка на трансформ персонажа
    public float smoothSpeed = 0.125f; // Сглаживание движения

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + new Vector3(0, 0, -10); // Устанавливаем позицию камеры на позиции персонажа
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Сглаживаем движение камеры

        transform.position = smoothedPosition; // Присваиваем новую позицию камере
    }
}