using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesOfFly : MonoBehaviour
{
    public Slider slider;

    public void SetLivesOfFly(int health)
    {
        slider.value = health;
    }

    public void SetMaxLivesOfFly(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
