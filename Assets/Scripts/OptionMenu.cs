using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OptionMenu : MonoBehaviour
{
    public GameObject optionUI;
    public GameObject mainMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        optionUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    // Update is called once per frame
    public void optionMenuOpen()
    {
        optionUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void optionMenuClose()
    {
        optionUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }


}
