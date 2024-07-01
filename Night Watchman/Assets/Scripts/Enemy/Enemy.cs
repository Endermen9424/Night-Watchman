using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health = 100;

    [SerializeField] protected float speed = 5;
    [SerializeField] protected Animator anim;

    protected float cooldown = 0;
    protected float timer;

    protected float distance;
    [SerializeField] protected float attackdistance;

    [SerializeField] protected Rigidbody rb;

    protected GameObject player;

    protected virtual void Start() {
        timer = cooldown;

        player = GameObject.FindGameObjectWithTag("Player");
        print(player);
    }

    protected void Update() {
        timer += Time.deltaTime;
        distance = transform.position.x - player.transform.position.x;
        if (distance < 0) {
            distance = -distance; // make it positive if enemy is to the left of player
        }

        print(distance);

        if (distance <= attackdistance) {
            Attack();
            rb.velocity = new Vector3(0, 0, 0);
        }
        else {
            Walk();
        }
    }

    protected virtual void Attack() {
        if (Time.timeScale >= 1) {
            if (timer > cooldown) {
                OnAttack();
                timer = 0;
            }
        }
    }

    protected virtual void OnAttack() {}

    protected virtual void Walk() {}
}
