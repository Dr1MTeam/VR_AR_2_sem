using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoOnCollision : MonoBehaviour
{
    [SerializeField]
    float threshold = 0.1f; // ѕороговое значение, которое вы определ€ете

    private Rigidbody rb;

    private Vector3 previousVelocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        // —охран€ем текущую скорость перед обновлением физики
        previousVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ѕолучаем вектор скорости объекта и нормализуем его
        Vector3 velocity = previousVelocity;
        Vector3 normalizedVelocity = velocity.normalized;

        // ѕолучаем вектор нормали плоскости коллизии
        Vector3 collisionNormal = collision.contacts[0].normal;

        // ¬ычисл€ем разность между нормализированным вектором скорости и вектором нормали плоскости коллизии
        Vector3 difference = normalizedVelocity + collisionNormal;

        // ¬ычисл€ем модуль этой разности
        float magnitudeDifference = difference.magnitude;



        // ѕровер€ем, меньше ли этот модуль определенного значени€
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
