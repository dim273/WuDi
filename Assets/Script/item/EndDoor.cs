using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        if (!Game.stoneboss_alive)
        {
            animator.SetTrigger("open");
            boxCollider.enabled = false;
        }   
    }
}
