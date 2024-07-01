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
    protected float attackdistance;

    [SerializeField] protected Rigidbody rb;

    protected GameObject player;

    protected virtual void Start() {
        timer = cooldown;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        timer += Time.deltaTime;
        distance = Mathf.Abs(transform.position.x - gameObject.transform.position.x);

        if (distance <= attackdistance) {
            Attack();
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
