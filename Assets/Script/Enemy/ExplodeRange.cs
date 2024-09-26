using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeRange : MonoBehaviour
{
    public int damage;
    [SerializeField]
    private float time = 0.2f;
    private PlayerHealthy healthy;
    void Start()
    {
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
            healthy.TakeDamage(damage);
        }
    }
}
