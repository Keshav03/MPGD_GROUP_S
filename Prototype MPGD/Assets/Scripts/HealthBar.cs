using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Class used for the UI displaying the player's Health attribute.
public class HealthBar : MonoBehaviour
{
    //Variables to be used.
    public Slider slider;

    //A function used to set the Health bar to max at the start of each game instance.
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //A function used to set the value of Health after being damaged by the enemy or after picking up Health pickups.
    public void SetHealth(int health)
    {
        slider.value = health;
    }

}
