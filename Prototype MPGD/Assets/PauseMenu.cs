using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject OptionsUI;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
        
        public void resume()
        {
        OptionsUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;

        }
        public void pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
        public void Options()
        {
        OptionsUI.SetActive(true);
        }
    
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
    }

