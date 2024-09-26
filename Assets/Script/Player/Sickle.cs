using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{
    public int output;
    public float power;
    private Rigidbody2D rb;
    private PolygonCollider2D pc2D;
    private float time;

    void Start()
    {
        time = 0.4f;
        rb = GetComponent<Rigidbody2D>();
        pc2D = GetComponent<PolygonCollider2D>();
        rb.velocity = transform.right * power + transform.up * 3;
        Destroy(gameObject, 6f);
    }


    void Update()
    {
        if (pc2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(output);
            Destroy(gameObject, time);
        }
    }
}
