using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PolygonCollider2D attack1;
    private PolygonCollider2D attack2;
    private float attack1_time = 0.2f;
    private float attack2_time = 0.2f;
    void Start()
    {
        attack1 = transform.Find("Attack1").GetComponent <PolygonCollider2D>();
        attack2 = transform.Find("Attack2").GetComponent <PolygonCollider2D>();
    }

    void Update()
    {
        
    }
    public void GenAttackOne()
    {
        attack1.enabled = true;
        Invoke("StopAttackOne", attack1_time);
    }
    void StopAttackOne()
    {
        attack1.enabled = false;
    }
    public void GenAttackTwo()
    {
        attack2.enabled = true;
        Invoke("StopAttackTwo", attack2_time);
    }
    void StopAttackTwo()
    {
        attack2.enabled = false;
    }
    
}
