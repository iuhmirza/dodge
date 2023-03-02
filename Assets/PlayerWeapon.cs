using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    float fireRateTimer;
    float fireRateCooldown;
    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        fireRateTimer = Time.time;
        fireRateCooldown = 5f;
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(body.position, transform.up);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(body.position, hitInfo.point, Color.red);
            if (Input.GetKeyDown(KeyCode.Space) && (fireRateTimer + fireRateCooldown > Time.time))
            {
                fireRateTimer = Time.time;
                Destroy(hitInfo.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawLine(body.position, body.transform.position + body.transform.up * 100, Color.green);
        }
    }
}
