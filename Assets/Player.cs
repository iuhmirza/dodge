using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 10f;
    public float health;
    Vector2 velocity;
    float screenHalfWidthInWorldUnits;
    public event System.Action OnPlayerDeath;
    SpriteRenderer sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth / 2f;
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        Vector2 direction = input.normalized;
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        body.position += velocity * Time.fixedDeltaTime;
        if (body.position.x > screenHalfWidthInWorldUnits)
        {
            body.position = new Vector2(-screenHalfWidthInWorldUnits, -2.5f);
        }
        if (body.position.x < -screenHalfWidthInWorldUnits)
        {
            body.position = new Vector2(screenHalfWidthInWorldUnits, -2.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float newHealth = health - collision.rigidbody.mass;
        if (newHealth <= 0)
        {
            if (OnPlayerDeath != null)
            {
                StartCoroutine(Die());
            }
        } else
        {
            health = newHealth;
            StartCoroutine(Flash());

        }

    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 7; i++)
        {
            yield return null;
            sprite.color = Color.HSVToRGB(0, i / 10f, 0.85f);
        }
        for (int i = 5; i >= 0; i--)
        {
            yield return null;
            sprite.color = Color.HSVToRGB(0, i / 10f, 0.85f);
        }
    }
    
    IEnumerator Die()
    {
        StopCoroutine(Flash());
        sprite.color = Color.HSVToRGB(0, 0, 0.85f);
        for (int i = 0; i < 11; i++)
        {
            yield return null;
            sprite.color = Color.HSVToRGB(0, i / 10f, 0.85f - i / 10f);
        }
        OnPlayerDeath();
        Destroy(gameObject);
    }
}
