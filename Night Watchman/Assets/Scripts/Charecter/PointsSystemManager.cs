using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsSystemManager : MonoBehaviour
{
    int Battle_Point = 0;

    [SerializeField] TMP_Text Battle_Point_Text_Field;

    private void Start() {
        if(PlayerPrefs.HasKey("Battle_Point"))
        {
            Battle_Point = PlayerPrefs.GetInt("Battle_Point");
            Battle_Point_Text_Field.text = Battle_Point.ToString() + "bp";
        }
    }

    public void Add_Battle_Point(int value) {
        Battle_Point += value;
        Battle_Point_Text_Field.text = Battle_Point.ToString() + "bp";
        PlayerPrefs.SetInt("Battle_Point", Battle_Point);
    }
}
