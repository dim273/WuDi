using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject sickle;
    public float CD;
    private bool shoot_if;
    private Animator animator;
    void Start()
    {
        shoot_if = true;
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1) && shoot_if && Game.player_alive)
        {
            animator.SetTrigger("shoot");
            Instantiate(sickle, transform.position, transform.rotation);
            StartCoroutine(CanShoot());
        } 
    }

    private IEnumerator CanShoot()
    {
        shoot_if= false;
        yield return new WaitForSeconds(CD);
        shoot_if = true;
    }
}
