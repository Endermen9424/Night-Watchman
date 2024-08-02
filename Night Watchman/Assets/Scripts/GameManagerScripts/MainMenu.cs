using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void Settings() {
        SceneManager.LoadScene("Settings");
    }

    public void Trader() {
        SceneManager.LoadScene("WaponsTraderScene");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
