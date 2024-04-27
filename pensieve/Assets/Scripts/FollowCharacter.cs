using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ссылка на трансформ персонажа
    private float smoothSpeed = 0.015f; // Сглаживание движения
    private Vector3 diff;
    void Start()
    {
        transform.position = target.position + Vector3.forward *-10;
    }
    
    void FixedUpdate()
    {
        diff = target.position - transform.position + Vector3.forward *-10;
        if ( diff.magnitude>1)
        {
            transform.position = Vector3.Lerp(transform.position, target.position+ Vector3.forward *-10, smoothSpeed); // Сглаживаем движение камеры
        }
    }
}