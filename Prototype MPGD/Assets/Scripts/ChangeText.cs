using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{

    public Text txt;
    // Start is called before the first frame update
    
    public void setText(int newText){
        txt.text = newText.ToString();
    }

    public void setText(string newText){
        txt.text = newText;
    }

}
