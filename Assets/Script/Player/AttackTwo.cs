using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class AttackTwo : MonoBehaviour
{
    public int output;
    private PolygonCollider2D PolygonCollider2D;
    void Start()
    {
        PolygonCollider2D = GetComponent<PolygonCollider2D>();  
    }


    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (SkillUI.skill_enenge < 10)
                SkillUI.skill_enenge++;
            other.GetComponent<Enemy>().TakeDamage(output);
            PolygonCollider2D.enabled = false;
        }
    }
}
