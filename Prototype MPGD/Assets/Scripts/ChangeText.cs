using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A script used for changing the text present in the UI.
public class ChangeText : MonoBehaviour
{
    //Variables to be used.
    public Text txt;
    
    //For the conversion of int variables to string variables to be used for the UI.
    public void setText(int newText){
        txt.text = newText.ToString();
    }

    //For string variables to be used for the UI.
    public void setText(string newText){
        txt.text = newText;
    }

}
