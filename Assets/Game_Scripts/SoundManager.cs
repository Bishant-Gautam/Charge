using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Update()
    {
        //This condition is made to manage the volume and store it on the playerprefs
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadVolume();
            
        }
        else
        {
            LoadVolume();
        }     
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }
    public void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");

    }
    //This ethod is made to save the volume once the player changes the settings
    public void SaveVolume()
    {
            PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}