using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
public class StoneGround : MonoBehaviour
{
    public int damage;
    public float time;
    private Rigidbody2D rb;
    private PlayerHealthy player_health;

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        Destroy(gameObject, time);
        player_health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthy>();
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (player_health != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, 7f);
                player_health.TakeDamage(damage);
            }
        }
    }

}
