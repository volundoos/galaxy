using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;//to check if game is paused
    public static bool ShopisOpened = false;//to check if shop is opened
    public static bool optionIsOpen = false;
    public GameObject pausemenuUI;
    public GameObject gameUI;

    public GameObject optionUI;

    private void Start()
    {
        //set all menu as inactivated except gameUI
        pausemenuUI.SetActive(false);
        gameUI.SetActive(true);

        optionUI.SetActive(false);
        GameisPaused = false;
        ShopisOpened = false;
        
    }
    void Update()
    {
        //if esc is pressed, pausemenu activates, gameUI inactivates
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused == true && optionIsOpen == false)
            {
                Resume();
            }
            else if(GameisPaused == false && optionIsOpen == false)
            {
                Pause();
            }
            else
            {
                optionClose();
            }

        }
    }

    //when pause menu got activated, the functions below work
    public void Resume()
    {
        pausemenuUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    public void Pause()
    {
        pausemenuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    //onclick event for to main menu
    public void toMainMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    //onclick event for to desktop
    public void toDesktop()
    {
        Debug.Log("quit");
        Application.Quit();
    }


    //optionui
    public void optionOpen()
    {
        optionUI.SetActive(true);
        pausemenuUI.SetActive(false);
        optionIsOpen = true;
    }

    public void optionClose()
    {
        optionUI.SetActive(false);
        pausemenuUI.SetActive(true);
        optionIsOpen = false;
    }
}
