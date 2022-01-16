using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//A class used to control the different states and elements of the game such as the UI, resets, etc.
public class GameController : MonoBehaviour
{
    //Variables to be used.
    public Text winText; //Variable used to display text telling the character if the game is won or lost.
    public Text Objectives;
    public Text Objectives2;
    public int target = 6; //Variable used for the win condition in relation to the pickups obtained.
    public int target2 = 6; //Variable used for the win condition in relation to the enemies killed.
    public int count; //Variable used to store the counter used for the pickups obtained.
    public int count2; //Variable used to store the counter used for the enemies killed.
    public FPSPlayer fpsc;

    // Start is called before the first frame update
    void Start()
    {
        GameObject fpsPlayer = GameObject.FindGameObjectWithTag("Player"); 
        fpsc = fpsPlayer.GetComponent<FPSPlayer>(); //
        count = 0; //Set pickups obtained to 0.
        count2 = 0; //Set enemies killed to 0.
        Objectives.text = "Items Collected: " + count;
        Objectives2.text = "Enemies Killed  : " + count2; //Set the text UI elements.
        //winText.text = ""; //Set the win/loss screen empty.

    }

    //Function used to alter the UI if a KeyItem pickup is obtained.
    public void ItemCollected()
    {
        count++;
        Objectives.text = "Items Collected: " + count;
        SetCountText();
        
    }
    
    //Function used to alter the UI if an enemy is killed.
    public void EnemyKilled()
    {
        count2++;
        Objectives2.text = "Enemies Killed: " + count2;
        SetCountText();
    }

    //Function used to set the UI displaying the pickups obtained, the enemies killed and also the win/loss screens.
    public void SetCountText()
    {

        //If game is won.
        if (count >= target && count2 >= target2)
        {
            Objectives.text = "";
            Objectives2.text = "";
            if (SceneManager.GetActiveScene().buildIndex < 3)
                {
                winText.text = "Level cleared!";
                StartCoroutine("Wait");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                winText.text = "Game finished!";
                StartCoroutine("Wait");
                SceneManager.LoadSceneAsync(0);

            }

        }
       
    }
    
    //Function used to reset the game if the game is lost (player health <= 0).
    //public void reset()
    //{
    //    StartCoroutine("Reset");
   // }

    //Coroutine used as part of the reset function.
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
}
