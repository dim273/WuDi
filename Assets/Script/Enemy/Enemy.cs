using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Healthy Info")]
    public int health;
    public int defense;
    protected bool dying;

    [Header("Check")]
    [SerializeField] protected Transform ground_check;
    [SerializeField] protected float ground_check_distance;
    [SerializeField] protected Transform wall_check;
    [SerializeField] protected float wall_check_distance;
    [SerializeField] protected LayerMask what_is_ground;
    protected bool is_ground;
    protected bool is_wall;

    protected int facing_dir = 1;
    protected bool facing_right = true;

    public GameObject float_point;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected virtual void Start()
    {
        dying = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        GroundCheck();
    }

    protected void GroundCheck()
    {
        is_ground = Physics2D.Raycast(ground_check.position, Vector2.down, ground_check_distance, what_is_ground);
        is_wall = Physics2D.Raycast(wall_check.position, Vector2.down, wall_check_distance * facing_dir, what_is_ground);
    }
    public void TakeDamage(int damage)
    {
        if (health > 0 && Game.game_begin)
        {
            int u = Mathf.Max(damage - defense, 1);
            GameObject gb = Instantiate(float_point, transform.position, Quaternion.identity) as GameObject;
            gb.transform.GetChild(0).GetComponent<TextMesh>().text = u.ToString();
            health -= u;
        }
        if (health <= 0 && !dying)
        {
            dying = true;
            anim.SetTrigger("die");
        }
    }
    protected virtual void Filp()
    {
        facing_dir = facing_dir * -1;
        facing_right = !facing_right;
        transform.Rotate(0, 180, 0);
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(ground_check.position, new Vector3(ground_check.position.x, ground_check.position.y - ground_check_distance));
        Gizmos.DrawLine(wall_check.position, new Vector3(wall_check.position.x - wall_check_distance, wall_check.position.y));
    }
}
