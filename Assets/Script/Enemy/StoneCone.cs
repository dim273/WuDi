using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCone : MonoBehaviour
{
    public int damage;
    public float time;
    private PlayerHealthy healthy;
    private Rigidbody2D rb;
    private PolygonCollider2D pc2D;
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        healthy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthy>();
        Destroy(gameObject, time);
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 6f);
            healthy.TakeDamage(damage);
        }
    }
}
