using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : MonoBehaviour
{
    Rigidbody2D body;
    SpriteRenderer sprite;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = GenerateRandomColor();
    }

    void Update()
    {
        float size = transform.localScale.magnitude;
        transform.Rotate(0, 0, 1 / size);
        if (body.position.y < -Camera.main.orthographicSize - size)
        {
            Destroy(gameObject);
        }
    }

    Color GenerateRandomColor()
    {
        return Color.HSVToRGB(Random.Range(0, 1f), Random.Range(0.4f, 0.8f), 1f);
    }
}
