using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject coin;
    public float time;
    [SerializeField]
    private bool can_open = true;
    private bool is_open = false;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (can_open && !is_open)
            {
                anim.SetTrigger("open");
                Invoke("GenCoin", time);
                is_open = true;
            }
        }
    }
    void GenCoin()
    {
        for (int i = 1; i < 4; i++)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            can_open = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            can_open = false;
        }
    }
}
