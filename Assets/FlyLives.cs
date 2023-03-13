using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyLives : MonoBehaviour
{
    public int maxLivesOfFly = 800;
    public int currentLivesOfFly;

    public LivesOfFly livesOfFly;

    void Start()
    {
        currentLivesOfFly = maxLivesOfFly;
        livesOfFly.SetMaxLivesOfFly(maxLivesOfFly);
    }
}
