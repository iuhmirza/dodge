using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : MonoBehaviour
{
    Rigidbody2D body;
    float screenHeightInWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        screenHeightInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
        if (transform.position.y < -screenHeightInWorldUnits)
        {
            Destroy(gameObject);
        }
    }
}
