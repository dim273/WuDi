using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAttack : MonoBehaviour
{
    public int damage;
    private PlayerHealthy healthy;
    void Start()
    {
        healthy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healthy.TakeDamage(damage);
        }
    }
}
