using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject cheap, medium, expensive, super;

    private void Start() {
        cheap.SetActive(true);
        medium.SetActive(false);
        expensive.SetActive(false);
        super.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            cheap.SetActive(true);
            medium.SetActive(false);
            expensive.SetActive(false);
            super.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            cheap.SetActive(false);
            medium.SetActive(true);
            expensive.SetActive(false);
            super.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            cheap.SetActive(false);
            medium.SetActive(false);
            expensive.SetActive(true);
            super.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            cheap.SetActive(false);
            medium.SetActive(false);
            expensive.SetActive(false);
            super.SetActive(true);
        }
    }
}
