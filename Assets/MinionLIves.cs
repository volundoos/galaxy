using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionLIves : MonoBehaviour
{
    public int maxLivesOfMinion = 200;
    public int currentLivesOfMinion;

    public LivesOfMinion livesOfMinion;

    void Start()
    {
        currentLivesOfMinion = maxLivesOfMinion;
        livesOfMinion.SetMaxLivesOfMinion(maxLivesOfMinion);
    }
}
