using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallerSpawner : MonoBehaviour
{
    public GameObject fallerPrefab;
    Vector2 screenHalfSizeWorldUnits;
    float spawnDelay;
    float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        spawnDelay = 1 / screenHalfSizeWorldUnits.x;
        InvokeRepeating("SpawnFaller", 0, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnFaller()
    {
        float randomSpawnSize = Random.Range(0.5f, 1.5f);
        Vector2 randomSpawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + 0.5f);
        Vector3 randomSpawnRotation = Vector3.forward * Random.Range(0, 59);

        GameObject newFaller = (GameObject)Instantiate(fallerPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
        newFaller.transform.localScale = Vector2.one * randomSpawnSize;
        newFaller.GetComponent<Rigidbody2D>().mass = randomSpawnSize;
    }
}
