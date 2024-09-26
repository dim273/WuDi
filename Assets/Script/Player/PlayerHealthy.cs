using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealthy : MonoBehaviour
{
    public static int health;
    public static bool inv;

    public int health_max;
    public float ink_time;


    private Animator animator;
    private Renderer my_renderer;


    void Start()
    {
        health = health_max;
        HealthBar.health_max = health;
        inv = false;
        animator = GetComponent<Animator>();
        my_renderer = GetComponent<Renderer>();

    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (!inv && Game.player_alive)
        {
            health -= damage;
            if(health < 0)
            {
                health = 0;
            }
            if(health == 0)
            {
                Game.player_alive = false;
                animator.SetTrigger("die");
            }
            inv = true;
            Invoke("Invisible", ink_time);
        }
    }
    void Invisible()
    {
        inv = false;
    }
    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
