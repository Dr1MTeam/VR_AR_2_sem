using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoOnCollision : MonoBehaviour
{
    [SerializeField]
    float threshold = 0.0f; // ��������� ��������, ������� �� �����������

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
        Vector3 velocity = previousVelocity;
        Vector3 normalizedVelocity = velocity.normalized;

        // �������� ������ ������� ��������� ��������
        Vector3 collisionNormal = collision.contacts[0].normal;

        // ��������� �������� ����� ����������������� �������� �������� � �������� ������� ��������� ��������
        Vector3 difference = normalizedVelocity + collisionNormal;

        // ��������� ������ ���� ��������
        float magnitudeDifference = difference.magnitude;

        Debug.Log(magnitudeDifference);


        // ���������, ������ �� ���� ������ ������������� ��������
        if (magnitudeDifference < threshold)
        {
            SpawnTerrainScanner();
        }

    }
    public GameObject TerrainScannerprefab;
    public float duration = 10;
    public float size = 500;
    void SpawnTerrainScanner()
    {
        GameObject terrainScanner = Instantiate(TerrainScannerprefab, gameObject.transform.position, Quaternion.identity) as GameObject;
        ParticleSystem terrainScannerPS = terrainScanner.transform.GetChild(0).GetComponent<ParticleSystem>();

        if (terrainScannerPS != null)
        {
            var main = terrainScannerPS.main;
            main.startLifetime = duration;
            main.startSize = size;
        }
        else
            Debug.Log("First child doesnt have particle system");

        Destroy(terrainScanner, duration + 1);
    }
}
