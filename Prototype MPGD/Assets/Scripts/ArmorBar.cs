using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxArmor(int shield)
    {
        slider.maxValue = shield;
        slider.value = shield;
    }

    public void SetArmor(int shield)
    {
        slider.value = shield;
    }  
        
    
}
