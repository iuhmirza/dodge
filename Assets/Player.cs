using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 10;
    Vector2 velocity;
    float screenHalfWidthInWorldUnits;
    public event System.Action OnPlayerDeath;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
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
            body.position = new Vector2(-screenHalfWidthInWorldUnits, -3f);
        }
        if (body.position.x < -screenHalfWidthInWorldUnits)
        {
            body.position = new Vector2(screenHalfWidthInWorldUnits, -3f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (OnPlayerDeath != null)
        {
        //    OnPlayerDeath();
        }
       // Destroy(gameObject);
    }
}
