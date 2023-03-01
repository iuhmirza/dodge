using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallerSpawner : MonoBehaviour
{
    public GameObject fallerPrefab;
    Vector2 screenHalfSizeWorldUnits;
    float spawnDelay;
    float nextDifficultyIncrease;
    float maxSpawnSize;
    float gravity;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        spawnDelay = 1 / screenHalfSizeWorldUnits.x * 2;
        InvokeRepeating("SpawnFaller", 0, spawnDelay);
        nextDifficultyIncrease = Time.time + 10f;
        maxSpawnSize = 1.5f;
        gravity = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextDifficultyIncrease)
        {
            nextDifficultyIncrease = 2 * Time.time;
            maxSpawnSize = Mathf.Min(maxSpawnSize + 0.5f, screenHalfSizeWorldUnits.x);
            gravity += 0.2f;
        }
    }

    void SpawnFaller()
    {
        float randomSpawnSize = Random.Range(0.5f, maxSpawnSize);
        Vector2 randomSpawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + randomSpawnSize);
        Vector3 randomSpawnRotation = Vector3.forward * Random.Range(0, 59);

        GameObject newFaller = (GameObject)Instantiate(fallerPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
        newFaller.transform.localScale = Vector2.one * randomSpawnSize;
        newFaller.GetComponent<Rigidbody2D>().mass = randomSpawnSize;
        newFaller.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

}
