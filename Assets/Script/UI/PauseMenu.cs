using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool game_pause = false;
    public GameObject pause;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (game_pause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1.0f;  
        game_pause = false;
    }
    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
        game_pause = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        game_pause = false ;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
        Game.player_alive = true;
        Game.stoneboss_alive = true;
        Game.game_begin = false;
}
}
