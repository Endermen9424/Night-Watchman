using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Slider slider;

    private void Start() {
        slider.value = PlayerPrefs.GetFloat("SoundValue", 1);
    }

    public void SaveSoundValue() {
        PlayerPrefs.SetFloat("SoundValue", slider.value);
    }

    public void GoBack() {
        SceneManager.LoadScene("MainMenu");
    }
}
