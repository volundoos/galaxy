using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesOfMinion : MonoBehaviour
{
    public Slider slider;

    public void SetLivesOfMinion(int health)
    {
        slider.value = health;
    }

    public void SetMaxLivesOfMinion(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
