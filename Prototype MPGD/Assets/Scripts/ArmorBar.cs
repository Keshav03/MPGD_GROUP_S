using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class used for the UI displaying the player's Armor attribute.
public class ArmorBar : MonoBehaviour
{
    //Variables to be used.
    public Slider slider;

    //A function used to set the Armor bar to max at the start of each game instance.
    public void SetMaxArmor(int shield)
    {
        slider.maxValue = shield;
        slider.value = shield;
    }
    //A function used to set the value of Armor after being damaged by the enemy or after picking up Armor pickups.
    public void SetArmor(int shield)
    {
        slider.value = shield;
    }  
        
    
}
