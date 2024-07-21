using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject particle;
    [SerializeField] protected GameObject cam;

    [SerializeField] protected PointsSystemManager pointManager;

    protected bool auto = false;
    protected float cooldown = 3;
    protected float timer;

    private void Start() {
        timer = cooldown;
    }

    private void Update() {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0)) {
            shoot();
        }
    }

    public void shoot() {
        if (Input.GetMouseButtonDown(0) && Time.timeScale >= 1 || auto) {
            if (timer > cooldown) {
                OnShoot();
                timer = 0;
            }
        }
    }

    protected virtual void OnShoot() {}
}
