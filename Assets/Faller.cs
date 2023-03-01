using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 screenHalfSizeWorldUnits;
    SpriteRenderer sprite;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = GenerateRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        float size = transform.localScale.magnitude;
        transform.Rotate(0, 0, 1 / size);
        if (body.position.y < -screenHalfSizeWorldUnits.y - size)
        {
            Destroy(gameObject);
        }
    }

    Color GenerateRandomColor()
    {
        return Color.HSVToRGB(Random.Range(0, 1f), Random.Range(0.4f, 0.8f), 1f);
    }
}
