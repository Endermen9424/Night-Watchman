using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float health = 100;
    
    void Update() {
        health = Mathf.Clamp(health, 0, 100);
    }

    public void ChangeHealth(float value) {
        health -= value;
        if (health <= 0) {
            Time.timeScale = 0;
        }
    }
}
