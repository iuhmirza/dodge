using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize * 2, Camera.main.orthographicSize * 2);
        spawnDelay = 2 / screenSize.x;
        gravityScale = screenSize.x / screenSize.y; // ratio is no good!
        maxSpawnSize = 0.1f * screenSize.x;
        nextDifficultyIncrease = 10f;
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
                    maxSpawnSize = Mathf.Min(maxSpawnSize + 0.1f, screenSize.x / 5);
                    break;
                case 2:
                    spawnDelay = Mathf.Max(spawnDelay - 0.1f, 0.1f);
                    break;

            }
            nextDifficultyTimer = Time.time;
        }
    }

}
