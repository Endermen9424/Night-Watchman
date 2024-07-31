using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeahtMenuScript : MonoBehaviour
{
    [SerializeField] GameObject DeahtMenu;
    [SerializeField] GameObject Battle_point_GameArea;

    [SerializeField] TMP_Text Battle_point_Area;
    [SerializeField] GameObject Health_Bar;

    [SerializeField] GameObject crosshair;

    [SerializeField] AudioSource audioSource;

    private void Start() {
        audioSource.volume = PlayerPrefs.GetFloat("SoundValue", 1);
    }
    public void Deaht() {
        Cursor.lockState = CursorLockMode.None;
        DeahtMenu.SetActive(true);
        Battle_point_GameArea.SetActive(false);
        Health_Bar.SetActive(false);
        crosshair.SetActive(false);
        if (PlayerPrefs.HasKey("Battle_Point")) {
            Battle_point_Area.text = PlayerPrefs.GetInt("Battle_Point").ToString() + "bp";
        }
    }

    public void Restart(){
        SceneManager.LoadScene("Game");
    }

    public void Go_to_the_MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
