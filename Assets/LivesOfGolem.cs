using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesOfGolem : MonoBehaviour
{
    public Slider slider;

    public void SetLivesOfGolem(int health)
    {
        slider.value = health;
    }

    public void SetMaxLivesOfGolem(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
