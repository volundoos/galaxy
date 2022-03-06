using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public void PlayGame()
    {
        Debug.Log("Game Loaded!");
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
