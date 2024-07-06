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
        Time.timeScale = 1;
        timer = cooldown;

        player = GameObject.FindGameObjectWithTag("Player");
        print(player);
    }

    void Update() {
        timer += Time.deltaTime;
        distance = transform.position.x - player.transform.position.x;
        if (distance < 0) {
            distance = -distance; // make it positive if enemy is to the left of player
        }

        print(distance);

        if (distance <= attackdistance) {
            StartCoroutine(RunAttack());
            rb.velocity = new Vector3(0, 0, 0);
        }
        else {
            Walk();
        }
    }

    protected virtual void Attack() {
        
        if (timer > cooldown) {
            OnAttack();
            timer = 0;
        }
        
    }

    protected virtual void OnAttack() {}

    protected virtual void Walk() {}

    protected void CloseAttack()
    {
        anim.SetBool("Attack", false);
    }

    public IEnumerator RunAttack() {
        while(true) {
            Attack();
            yield return new WaitForSeconds(1);
        }
    } 
}
