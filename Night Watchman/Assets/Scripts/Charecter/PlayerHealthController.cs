using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public float health = 100;
    [SerializeField] GameObject HealthBar;
    
    void Update() {
        health = Mathf.Clamp(health, 0, 100);
    }

    public void ChangeHealth(float value) {
        health -= value;
        HealthBar.GetComponent<Slider>().value = health;
        if (health <= 0) {
            Time.timeScale = 0;
        }
    }
}
