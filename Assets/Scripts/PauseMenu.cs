using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame = false;
    public GameObject pauseMenu;
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            PauseGame = false;
        }
        void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseGame = true;
        }
    }
}
