using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;

    [SerializeField] float speed = 5;
    [SerializeField] Animator anim;

    protected float cooldown = 0;
    protected float timer;

    float distance;
    float attackdistance;

    GameObject player;

    protected virtual void Start() {
        timer = cooldown;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        timer += Time.deltaTime;
        distance = Vector3.Distance(transform.position, gameObject.transform.position);

        if (distance <= attackdistance) {
            Attack();
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
}
