using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    public Text score;
    public int scoregot;
    void Start()
    {
        scoregot = 0;
    }

    public void getScore(int number)
    {
        scoregot += number;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoregot.ToString();
    }
}
