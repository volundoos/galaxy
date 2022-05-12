using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public static bool GameisPaused = false;//to check if game is paused
    public static bool UpgradeisOpened = false;//to check if shop is opened
    public static bool GameUIIsOpen = true;

    public GameObject UpgradeUI;
    public GameObject gameUI;

    void Start()
    {
        UpgradeUI.SetActive(false);
        gameUI.SetActive(true);

        GameisPaused = false;
        UpgradeisOpened = false;
        GameUIIsOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUpgrade()
    {
        UpgradeisOpened = true;
        GameisPaused = true;
        GameUIIsOpen = false;
        Time.timeScale = 0f;

        UpgradeUI.SetActive(true);
        gameUI.SetActive(false);
    }

    public void BackUpgrade()
    {
        UpgradeisOpened = false;
        GameisPaused = false;
        GameUIIsOpen = true;
        Time.timeScale = 1f;

        UpgradeUI.SetActive(false);
        gameUI.SetActive(true);
    }
}
