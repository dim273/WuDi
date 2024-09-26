using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public int damage;
    private PolygonCollider2D pc2D;
    void Start()
    {
        pc2D = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void AttackOpen()
    {
        pc2D.enabled = true;
    }
    public void AttackClose() 
    { 
        pc2D.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        { 
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
