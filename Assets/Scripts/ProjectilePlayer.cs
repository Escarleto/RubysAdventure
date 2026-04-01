using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectilePlayer : MonoBehaviour
{
    private Rigidbody2D Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.magnitude > 100f) Destroy(gameObject);
    }

    public void Launch(Vector2 Dir, float Spd)
    {
        Rb.AddForce(Dir * Spd, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMovement Enemy = collision.GetComponent<EnemyMovement>();
        Debug.Log("Collided with " + collision.gameObject.name);
        if (Enemy != null) Enemy.Die();

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
