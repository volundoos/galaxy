using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemLives : MonoBehaviour
{
    public int maxLivesOfGolem = 1400;
    public int currentLivesOfGolem;

    public LivesOfGolem livesOfGolem;

    void Start()
    {
        currentLivesOfGolem = maxLivesOfGolem;
        livesOfGolem.SetMaxLivesOfGolem(maxLivesOfGolem);
    }
}
