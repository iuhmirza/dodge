using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 1;
    Vector2 velocity;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
        if (body.position.x > 7.5)
        {
            body.position = new Vector2(-7.5f, -3f);
        }
        if (body.position.x < -7.5)
        {
            body.position = new Vector2(7.5f, -3f);
        }
    }
}
