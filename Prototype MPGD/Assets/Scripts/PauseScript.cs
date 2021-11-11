using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script used to pause or resume the game whenever the player presses the Esc button on their keyboard.
public class PauseScript : MonoBehaviour
{
    //Variables to be used.
    public static bool GameIsPause = false;
    public GameObject pauseMenu ;

    void Update()
    {
        //If Esc is pressed on the keyboard.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    //Used to make the game be on a state of 'Resume' when the game starts such that the Pause Menu does not appear.
    void Start()
    {
        Resume();
    }

    //Used to set the game's state to active if the game is on a state of 'Resume'. Removes the Pause menu.
    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    //Used to set the game's state to inactive if the game is on a state of 'Pause'. Displays the Pause Menu.
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }


}
