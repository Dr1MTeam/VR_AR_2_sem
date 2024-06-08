using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoOnCollision : MonoBehaviour
{
    [SerializeField]
    float threshold = 0.1f; // Пороговое значение, которое вы определяете

    private Rigidbody rb;

    private Vector3 previousVelocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        // Сохраняем текущую скорость перед обновлением физики
        previousVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Получаем вектор скорости объекта и нормализуем его
        Vector3 velocity = rb.velocity;
        Vector3 normalizedVelocity = velocity.normalized;

        // Получаем вектор нормали плоскости коллизии
        Vector3 collisionNormal = collision.contacts[0].normal;

        // Вычисляем разность между нормализированным вектором скорости и вектором нормали плоскости коллизии
        Vector3 difference = normalizedVelocity + collisionNormal;

        // Вычисляем модуль этой разности
        float magnitudeDifference = difference.magnitude;

        // Проверяем, меньше ли этот модуль определенного значения
        if (magnitudeDifference < threshold)
        {
            // Вызовите вашу функцию здесь
            // YourFunction();
        }
    }
}
