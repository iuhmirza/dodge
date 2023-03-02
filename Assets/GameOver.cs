using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public event System.Action TheGameIsOver;
    public GameObject gameOverScreen;
    public TextMeshProUGUI distance;
    bool gameOver;
    float elapsedTime;
    public float holdThrow = 0.1f;
    float holdTimer;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
        elapsedTime = Time.time;
        holdTimer = holdThrow;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.anyKey)
            {
                holdTimer -= Time.deltaTime;
                if (holdTimer < 0)
                    SceneManager.LoadScene(0);
                    elapsedTime = Time.time;
            }
            else
                holdTimer = holdThrow;
        }
    }

    void OnGameOver()
    {
        distance.text = ((int)(Time.time - elapsedTime)).ToString() + "m";
        gameOverScreen.SetActive(true);
        TheGameIsOver();
        gameOver = true;
    }
}
