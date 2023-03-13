using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Durability : MonoBehaviour
{
    public Slider slider;
   
    public void SetDurability(int dura)
    {
        slider.value = dura;
    }

    public void SetMaxDura(int dura)
    {
        slider.maxValue = dura;
        slider.value = dura;
    }
}
