using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 screenHalfSizeWorldUnits;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
        if (transform.position.y < -screenHalfSizeWorldUnits.y - 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
