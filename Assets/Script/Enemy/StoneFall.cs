using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneFall : MonoBehaviour
{
    
    public int damage;
    public GameObject explode_range;
    private Rigidbody2D rb;
    private PolygonCollider2D pc2D;
    private PolygonCollider2D son_pc2D;
    private Animator animator;
    private PlayerHealthy player_healthy;
    
    void Start()
    {
        son_pc2D = transform.Find("fallstone").GetComponent<PolygonCollider2D>();  
        pc2D = GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
        player_healthy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthy>();
    }

    void Update()
    {
        if (son_pc2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            animator.SetTrigger("explode");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player_healthy.TakeDamage(damage);
            animator.SetTrigger("explode");
        }
    }
    
    void Explode()
    {
        Instantiate(explode_range, transform.position, Quaternion.identity);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
