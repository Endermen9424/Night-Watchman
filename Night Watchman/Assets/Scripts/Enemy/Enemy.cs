using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health = 100;

    [SerializeField] protected float speed = 5;
    [SerializeField] protected Animator anim;

    [SerializeField] protected PointsSystemManager pointManager;

    protected float cooldown = 0;
    protected float timer;

    protected bool isDeath;

    public float attackVelocity;

    protected float distance;
    [SerializeField] protected float attackdistance;

    [SerializeField] protected Rigidbody rb;

    protected GameObject player;

    protected bool conditionMet;
    protected bool coroutineRunning = false;

    protected virtual void Start() {
        Time.timeScale = 1;
        timer = cooldown;

        player = GameObject.FindGameObjectWithTag("Player");
        pointManager = FindFirstObjectByType<PointsSystemManager>();
    }

    protected void Update() {
        health = Mathf.Clamp(health, 0, health);

        timer += Time.deltaTime;
        distance = transform.position.x - player.transform.position.x;
        if (distance < 0) {
            distance = -distance; // make it positive if enemy is to the left of player
        }

        if (distance <= attackdistance && !conditionMet && !coroutineRunning) {
            StartCoroutine(RunAttack());
            rb.velocity = new Vector3(0, 0, 0);
            conditionMet = false;
            coroutineRunning = true;
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
            if (!isDeath)
            {
                Attack();
                yield return new WaitForSeconds(1f);
            }
            
        }
    }

    public void ChangeHealth(float value) {
        health -= value;
        if (health <= 0) {
            isDeath = true;
            Destroy(gameObject, 0.3f);
            pointManager.Add_Battle_Point(20);
        }
    }
}
