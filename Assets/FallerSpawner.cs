using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallerSpawner : MonoBehaviour
{
    public GameObject fallerPrefab;
    public Difficulty difficulty;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        FindObjectOfType<GameOver>().TheGameIsOver += OnGameOver;
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
            SpawnFaller();
            yield return new WaitForSeconds(difficulty.spawnDelay);
        }
    }

    void OnGameOver()
    {
        difficulty.gravityScale = 0;
    }

}
