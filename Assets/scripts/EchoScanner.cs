using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class EchoScanner : MonoBehaviour
{
    public GameObject TerrainScannerprefab; 
    public float duration = 10;
    public float size = 500;

        [SerializeField]
     SteamVR_Action_Boolean echo = null;

 
    void Update()
    {

        echo = SteamVR_Actions.default_Echo;
        
        if (echo.state)
        {
            SpawnTerrainScanner();
        }
    }

    void SpawnTerrainScanner    ()
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
