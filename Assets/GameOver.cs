using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public event System.Action Over;
    
    public GameObject gameOverScreen;
    public TextMeshProUGUI distance;
    public GameObject image;
    
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
                    SceneManager.LoadScene(1);
                    elapsedTime = Time.time;
            }
            else
                holdTimer = holdThrow;
        }
    }

    void OnGameOver()
    {
        distance.text = ((int)(Time.time - elapsedTime)).ToString() + "m";
        StartCoroutine(DisplayGameOverScreen());
        Over();
    }

    IEnumerator DisplayGameOverScreen()
    {

        image.transform.localScale = new Vector2(Camera.main.aspect * Camera.main.orthographicSize * 2, Camera.main.orthographicSize * 2);
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 9; i++)
        {
            image.GetComponent<Image>().color = new Color(0, 0, 0, i / 10f);
            yield return new WaitForSeconds(0.1f);
        }

        gameOverScreen.SetActive(true);
        gameOver = true;

    }
}
