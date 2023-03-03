using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D body;
    float speed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.position += Vector2.up * speed * Time.fixedDeltaTime;
        if (body.position.y > Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
