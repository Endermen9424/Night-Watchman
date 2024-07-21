using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeahtMenuScript : MonoBehaviour
{
    [SerializeField] GameObject DeahtMenu;
    [SerializeField] GameObject Battle_point_GameArea;
    [SerializeField] GameObject Health_Bar;

    public void Deaht() {
        Cursor.lockState = CursorLockMode.None;
        DeahtMenu.SetActive(true);
        Battle_point_GameArea.SetActive(false);
        Health_Bar.SetActive(false);
    }

    public void Restart(){
        SceneManager.LoadScene("Game");
    }
}
