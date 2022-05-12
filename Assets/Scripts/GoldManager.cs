using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text gold;
    public int goldGot;
    void Start()
    {
        goldGot = 200;
    }

    public void getGold(int number)
    {
        goldGot += number;
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = goldGot.ToString();
    }
}
