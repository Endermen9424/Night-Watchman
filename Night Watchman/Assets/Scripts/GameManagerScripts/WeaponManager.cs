using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] TMP_Text cheap, medium, expensive, super;

    bool Cheap, Medium, Expensive, Super;

    [SerializeField] PointsSystemManager pointsSystemManager;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {SceneManager.LoadScene("MainMenu");}
    }

    private void Start() {
            if (PlayerPrefs.GetInt("cheap", 1) == 2) {
                cheap.text = "Equiped";
                PlayerPrefs.SetInt("Weapon", 1);
                Cheap = true;
            }
            else if (PlayerPrefs.GetInt("cheap", 1) == 1) {
                cheap.text = "Equip";
                Cheap = true;
            }

            if (PlayerPrefs.GetInt("medium", 0) == 2) {
                medium.text = "Equiped";
                PlayerPrefs.SetInt("Weapon", 2);
                Medium = true;
            }
            else if (PlayerPrefs.GetInt("medium", 0) == 1) {
                medium.text = "Equip";
                Medium = true;
            }

            if (PlayerPrefs.GetInt("expensive", 0) == 2) {
                expensive.text = "Equiped";
                PlayerPrefs.SetInt("Weapon", 3);
                Expensive = true;
            }
            else if (PlayerPrefs.GetInt("expensive", 0) == 1) {
                expensive.text = "Equip";
                Expensive = true;
            }
        
            if (PlayerPrefs.GetInt("super", 0) == 2) {
                super.text = "Equiped";
                PlayerPrefs.SetInt("Weapon", 4);
                Super = true;
            }
            else if (PlayerPrefs.GetInt("super", 0) == 1) {
                super.text = "Equip";
                Super = true;
            }
    }

    public void BuyWeapon(string weaponname) {
        if (weaponname == "medium" && PlayerPrefs.GetInt("Battler_Point", 0) >= 3000 && PlayerPrefs.GetInt("cheap", 1) != 1 || PlayerPrefs.GetInt("cheap", 1) != 2) {
            pointsSystemManager.Add_Battle_Point(-3000);
            PlayerPrefs.SetInt("medium", 1);
            medium.text = "Equip";
            Medium = true;
        }
        else if (weaponname == "expensive" && PlayerPrefs.GetInt("Battler_Point", 0) >= 7000 && PlayerPrefs.GetInt("cheap", 1) != 1 || PlayerPrefs.GetInt("cheap", 1) != 2) {
            pointsSystemManager.Add_Battle_Point(-7000);
            PlayerPrefs.SetInt("expensive", 1);
            expensive.text = "Equip";
            Expensive = true;
        }
        else if (weaponname == "super" && PlayerPrefs.GetInt("Battler_Point", 0) >= 30000 && PlayerPrefs.GetInt("cheap", 1) != 1 || PlayerPrefs.GetInt("cheap", 1) != 2) {
            pointsSystemManager.Add_Battle_Point(-30000);
            PlayerPrefs.SetInt("super", 1);
            super.text = "Equip";
            Super = true;
        }
    }
}
