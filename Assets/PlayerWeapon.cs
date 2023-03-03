using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    float fireRateTimer;

    Rigidbody2D body;
    public GameObject projectilePrefab;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        fireRateTimer = Time.time;

        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > fireRateTimer + 0.5f)) {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = new Vector2(body.position.x, -2.5f);
            fireRateTimer = Time.time;
        }
    }
}
