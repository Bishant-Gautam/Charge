using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class is made to manage the health bar setttings
public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    // Update is called once per frame

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
