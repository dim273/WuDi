using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private CapsuleCollider2D CapsuleCollider2D;
    private BoxCollider2D BoxCollider2D;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("open", true);
        BoxCollider2D = GetComponent<BoxCollider2D>();  
        CapsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BoxCollider2D.enabled = true;
            CapsuleCollider2D.enabled = false;
            animator.SetBool("open", false);
            Game.game_begin = true;
        }
    }
}
