using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text Objectives;
    public Text Objectives2;
    public Text winText;
    public int count;
    public int target = 6;
    public int target2 = 12;
    public int count2;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        count2 = 0;
        SetCountText();
        winText.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ItemCollected()
    {
        count++;
        SetCountText();
        
    }
    public void EnemyKilled()
    {
        count2++;
        SetCountText();
    }
    public void SetCountText()
    {
        Objectives.text = "Key items picked: " + count.ToString();
        Objectives2.text = "Enemies killed: " + count2.ToString();
        if (count >= target && count2 >= target2)
        {
            Objectives.text = "";
            Objectives2.text = "";
            winText.text = "You Win!";
        }
       
    }
}
