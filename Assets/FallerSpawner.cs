using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallerSpawner : MonoBehaviour
{
    public GameObject fallerPrefab;
    float screenHalfWidthInWorldUnits;
    float screenHeightInWorldUnits;
    float spawnDelay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        screenHeightInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        InvokeRepeating("SpawnFaller", 0, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnFaller()
    {
        Vector2 randomSpawnPosition = new Vector2(Random.Range(-screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits), screenHeightInWorldUnits);
        Vector3 randomSpawnRotation = Vector3.forward * Random.Range(0, 59);

        Instantiate(fallerPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
    }
}
