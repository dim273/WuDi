using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [Header("Move Info")]
    public float move_speed;
    private float xInput;
    private int facing_dir = 1;
    private bool facing_right = true;

    [Header("Jump Info")]
    public float jump_speed;
    public float double_jump_speed;
    public int init_jump_times;
    [SerializeField] private int jump_times;
    [SerializeField] private float jump_check_distance;
    [SerializeField] private LayerMask what_is_ground;
    private bool feet_groud;

    [Header("Dash Info")]
    public float dash_power;
    [SerializeField] private float dash_CD;
    private float dashing_time = 0.2f;
    private bool can_dash = true;
    private bool dashing = false;

    [Header("Attack Info")]
    [SerializeField] private bool attacking;
    [SerializeField] private float combo_time;
    private float attack_time;
    private int attack_cnt = 0;

    private Rigidbody2D rb;
    private Animator anim;
    private ReleaseThunder releaseThunder;
    private CapsuleCollider2D capsule;
    
    void Start()
    {
        jump_times = init_jump_times;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider2D>();
        releaseThunder = transform.Find("Skill").GetComponent<ReleaseThunder>();
    }
    void Update()
    {
        if (Game.player_alive)
        {
            Move();
            InputCheck();
            FilpController();
            AnimationController();
            attack_time -= Time.deltaTime;
            ReleaseThunder();
            InGround();
        }
    }
    private void InputCheck()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && can_dash)
        {
            StartCoroutine(Dash());
        }
        if (Input.GetMouseButtonDown(0) && !dashing)
        {
            Attack();
        }
    }
    private void AnimationController()
    {
        bool player_has_x_speed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetFloat("jump", rb.velocity.y);
        anim.SetBool("isGround", feet_groud);
        anim.SetBool("move", player_has_x_speed);
        anim.SetBool("attack", attacking);
        anim.SetInteger("attackCounter", attack_cnt);
    }
    private void Move()
    {
        if (dashing)
        {
            rb.velocity = new Vector2(facing_dir * dash_power, rb.velocity.y);
        }
        else if (attacking)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(xInput * move_speed, rb.velocity.y);
        }
    }
    private void Filp()
    {
        facing_dir = -1 * facing_dir;
        facing_right = !facing_right;
        transform.Rotate(0, 180, 0);
    }
    void FilpController()
    {
        if(rb.velocity.x > 0 && !facing_right)
        {
            Filp();
        }
        else if(rb.velocity.x < 0 && facing_right)
        {
            Filp();
        }
    }
    private void Jump()
    {
        if (feet_groud)
        {
            jump_times = init_jump_times;
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
        }
        else if (jump_times > 0)
        {
            jump_times--;
            rb.velocity = new Vector2(rb.velocity.x, double_jump_speed);
        }
    }
    private void InGround()
    {
        feet_groud = Physics2D.Raycast(transform.position, Vector2.down, jump_check_distance, what_is_ground);
    }
    public void AttackOver()
    {
        attacking = false;
        attack_cnt++;
        if (attack_cnt > 1)
        {
            attack_cnt = 0; 
        }
    }
    private void Attack()
    {
        if(attack_time < 0)
        {
            attack_cnt = 0;
        }
        attacking = true;
        attack_time = combo_time;
    }
    private IEnumerator Dash()
    {
        capsule.enabled = false;
        can_dash = false;
        dashing = true;
        float dash_gravity = rb.gravityScale;
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(dashing_time);
        capsule.enabled = true;
        dashing = false;
        rb.gravityScale = dash_gravity;
        yield return new WaitForSeconds(dash_CD);
        can_dash = true;
    }
    void ReleaseThunder()
    {
        if (!attacking)
        {
            if (Input.GetKeyDown(KeyCode.Q) && SkillUI.skill_enenge == 10)
            {
                anim.SetTrigger("big");
                StartCoroutine("TriggerIf");
            }
        }
    }
    void ThunderShow()
    {
        releaseThunder.Thunder();
    }
    private IEnumerator TriggerIf()
    {
        capsule.enabled = false;
        yield return new WaitForSeconds(2f);
        capsule.enabled = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - jump_check_distance));
    }
}