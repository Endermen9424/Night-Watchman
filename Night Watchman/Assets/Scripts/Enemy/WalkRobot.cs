using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRobot : Enemy
{
    protected override void Walk() {
        rb.velocity = new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
