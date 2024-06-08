using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoOnCollision : MonoBehaviour
{
    [SerializeField]
    float threshold = 0.1f; // ��������� ��������, ������� �� �����������

    private Rigidbody rb;

    private Vector3 previousVelocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        // ��������� ������� �������� ����� ����������� ������
        previousVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �������� ������ �������� ������� � ����������� ���
        Vector3 velocity = rb.velocity;
        Vector3 normalizedVelocity = velocity.normalized;

        // �������� ������ ������� ��������� ��������
        Vector3 collisionNormal = collision.contacts[0].normal;

        // ��������� �������� ����� ����������������� �������� �������� � �������� ������� ��������� ��������
        Vector3 difference = normalizedVelocity + collisionNormal;

        // ��������� ������ ���� ��������
        float magnitudeDifference = difference.magnitude;

        // ���������, ������ �� ���� ������ ������������� ��������
        if (magnitudeDifference < threshold)
        {
            // �������� ���� ������� �����
            // YourFunction();
        }
    }
}
