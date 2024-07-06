using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRobot : Enemy
{
    protected override void Walk() {
        rb.velocity = new Vector3(-speed, 0, 0);
    }

    protected override void OnAttack()
    {
        anim.SetBool("Attack", true);
        Invoke("CloseAttack", 0.1f);
    }
}
