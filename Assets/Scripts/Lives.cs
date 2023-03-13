using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Lives : MonoBehaviour
{
    public Text lives;
    public GameObject gameOverUi;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            lives.text = (int.Parse(lives.text)-1).ToString();
            Debug.Log("Collided");
            if(lives.text.ToString() == "0")
            {
                Debug.Log("Game Ended");
                gameOverUi.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
