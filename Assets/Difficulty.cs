using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    public float spawnDelay;
    public float maxSpawnSize;
    public float gravityScale;

    public Vector2 screenSize;

    float nextDifficultyIncrease;
    float nextDifficultyTimer;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            FindObjectOfType<GameOver>().Over += OnGameOver;
        }
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize * 2, Camera.main.orthographicSize * 2);
        spawnDelay = 1 / Mathf.Sqrt(screenSize.x);
        gravityScale = 1f;
        maxSpawnSize = 0.1f * screenSize.x;
        nextDifficultyIncrease = 1f;
        nextDifficultyTimer = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time > nextDifficultyTimer + nextDifficultyIncrease)
        {
            int choice = Random.Range(0, 3);
            switch (choice)
            {
                case 0:
                    gravityScale = Mathf.Min(gravityScale + 0.1f, 2f);
                    break;
                case 1:
                    maxSpawnSize = Mathf.Min(maxSpawnSize + 0.5f, screenSize.x / 3f);
                    break;
                case 2:
                    spawnDelay = Mathf.Max(spawnDelay - 0.1f, 0.1f);
                    break;

            }
            nextDifficultyTimer = Time.time;
            nextDifficultyIncrease *= 2;
        }
    }

    void OnGameOver()
    {
        spawnDelay = 1 / Mathf.Sqrt(screenSize.x);
        gravityScale = 2f;
        maxSpawnSize = screenSize.x / 3f;
        nextDifficultyIncrease = 5f;
        nextDifficultyTimer = Time.time;
    }

}
