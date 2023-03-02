using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    float fireRateTimer;
    float fireRateCooldown;
    Rigidbody2D body;
    public GameObject projectilePrefab;

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
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > fireRateTimer + fireRateCooldown)) {
            RaycastHit2D hitInfo = Physics2D.Raycast(body.position, transform.up);
            StartCoroutine(Shoot(body.position, hitInfo));
            fireRateTimer = Time.time;
        }
    }

    IEnumerator Shoot(Vector2 start, RaycastHit2D hit)
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = start;
        if (hit.collider != null) {
            while (true)
            {
                projectile.transform.position += Vector3.up;
                yield return null;
                if (projectile.transform.position.y >= hit.collider.attachedRigidbody.position.y)
                {
                    break;
                }
            }
        } else {
            while (true)
            {
                projectile.transform.position += Vector3.up;
                yield return null;
                if (projectile.transform.position.y >= 5f)
                {
                    break;
                }
            }
        
        }
        Destroy(hit.collider.gameObject);
        Destroy(projectile);
    }
}
