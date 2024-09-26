using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class StoneBoss : Enemy
{
    
    public float speed;
    public float attack_pos;

    public GameObject stone_cone;
    public GameObject stone_ground;
    public GameObject fall_stone;
    public Transform player;

    private PolygonCollider2D pc2d;
    private PolygonCollider2D common_attack;
    

    [SerializeField]
    private bool moving = true;
    private bool crazy = false; 
    public bool can_move = true;
    private int init_health;

    private bool can_attack = true;
    private float near_attack_CD = 3;
    private bool near_attack_if = true;
    private float far_attack_CD = 12;
    private bool far_attack_if = true;

    private float anim_speed = 0.2f;
    private float anim_reset = 0.8f;
    protected override void Start()
    {
        BossBar.boss_health = health;
        base.Start();
        init_health = health;
        pc2d = GetComponent<PolygonCollider2D>();
        common_attack = transform.Find("commonattack").GetComponent<PolygonCollider2D>();
        if (wall_check == null) wall_check = transform;
        if(ground_check == null) ground_check = transform;  
    }

    protected override void Update()
    {
        BossBar.boss_health = health;
        base.Update();
        if(Game.game_begin)
        {
            
            Game.stoneboss_alive = !dying;
            if (!crazy && health <= init_health / 2)
            {
                crazy = true;
                attack_pos += 0.8f;
                defense += 2;
                speed += 1;
            }
            if (!dying)
            {
                if (can_move)
                {
                    Move();
                    Filp();
                }
                AnimatorSet();
                if (can_attack)
                {
                    Attack();
                }
            }
        }
    }

    void Move()
    {
        float distance = Mathf.Abs(transform.position.x - player.position.x);
        if (distance > attack_pos)
        {
            moving = true;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            moving = false;
        }
    }
    void CanMoveController()
    {
        can_move = true;
        can_attack = true;
    }
    new void Filp()
    {
        if (transform.position.x > player.position.x) 
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void AnimatorSet()
    {
        anim.SetBool("move", moving);
    }
    void Attack()
    {
        if (!moving)
        {
            if(near_attack_if)
            {
                can_move = false;
                int choose;
                System.Random atk_choose = new System.Random();
                if (!crazy)
                {
                    choose = atk_choose.Next(1, 2);
                }
                else
                {
                    choose = atk_choose.Next(1, 3);
                }
                if(choose == 1)
                {
                    anim.SetTrigger("attack1");
                }
                else
                {
                    anim.SetTrigger("attack2");
                }
                can_attack = false;
                StartCoroutine(NearAttackCD());
            }
        }
        else
        {
            if (far_attack_if)
            {
                moving = false;
                can_move = false;
                int choose;
                System.Random atk_choose = new System.Random();
                if (!crazy)
                {
                    choose = atk_choose.Next(1, 2);
                }
                else
                {
                    choose = atk_choose.Next(1, 3);
                }
                if(choose == 1)
                {
                    anim.SetTrigger("attack3");
                }
                else
                {
                    anim.SetTrigger("attack4");
                }
                StartCoroutine(FarAttackCD());
                can_attack = false;
            }
        }
    }
    void AttackOne()
    {
        SoundManage.PlayBossAttackSound();
        common_attack.enabled = true;
        Invoke("ResetCommonAttack", 0.05f);
        if (crazy)
        {
            Vector3 gen_cone = new Vector3(player.transform.position.x, -4f, 0f);
            Instantiate(stone_cone, gen_cone, Quaternion.identity); 
        }
    }
   
    void ResetCommonAttack()
    {
        common_attack.enabled = false;
    }
    void AttackTwo()
    {
        Vector3 gen_cone = new Vector3(player.transform.position.x, -4f, 0f);
        Instantiate(stone_cone, gen_cone, Quaternion.identity);
    }
    void AttackThree()
    {
        System.Random rand = new System.Random();
        int u = rand.Next(-4, 19);
        Vector3 gen_stone = new Vector3((float)u, 9f, 0f);
        Instantiate(fall_stone, gen_stone, Quaternion.identity);
        
    }
    void AttackFour() 
    {
        Instantiate(stone_ground, transform.position, Quaternion.identity);
    }
    void AnimSpeed()
    {
        anim.speed = anim_speed;
        Invoke("AnimSpeedReset", anim_reset);
    }
    void AnimSpeedReset()
    {
        anim.speed = 1;
    }
    private IEnumerator NearAttackCD()
    {
        near_attack_if = false;
        yield return new WaitForSeconds(near_attack_CD);
        near_attack_if = true;
    }
    private IEnumerator FarAttackCD()
    {
        far_attack_if = false;
        yield return new WaitForSeconds (far_attack_CD);
        far_attack_if = true;
    }

}
