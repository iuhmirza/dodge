using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallerSpawner : MonoBehaviour
{
    public GameObject fallerPrefab;
    public Difficulty difficulty;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void SpawnFaller()
    {
        float randomSpawnSize = Random.Range(0.5f, difficulty.maxSpawnSize);
        
        Vector2 randomSpawnPosition = new Vector2(
            Random.Range(-difficulty.screenSize.x / 2f, difficulty.screenSize.x / 2f),
            difficulty.screenSize.y / 2f + randomSpawnSize);

        Vector3 randomSpawnRotation = Vector3.forward * Random.Range(0, 59);

        GameObject newFaller = (GameObject)Instantiate(fallerPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));

        Rigidbody2D newFallerBody = newFaller.GetComponent<Rigidbody2D>();
        newFallerBody.transform.localScale = Vector2.one * randomSpawnSize;
        newFallerBody.mass = randomSpawnSize;
        newFallerBody.gravityScale = difficulty.gravityScale;
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(difficulty.spawnDelay);
            SpawnFaller();
        }
    }
}
