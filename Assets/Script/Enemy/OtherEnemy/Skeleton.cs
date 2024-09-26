using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public int move_speed;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        rb.velocity = new Vector2(facing_dir * move_speed, rb.velocity.y);
        if (is_wall || !is_ground)
        {
            Filp();
        }
    }
}
