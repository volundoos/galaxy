using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgradeUI : MonoBehaviour
{
    public bool TurretUIisOpen;

    [SerializeField] private string turret = "Turret";
    void Start()
    {
        gameObject.SetActive(false);
        TurretUIisOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 2000.0f))
            {
                if (hit.transform != null)
                {
                    Debug.Log("Detected");
                    if (hit.transform.CompareTag(turret))
                    {
                        Debug.Log("Hit");
                        if (TurretUIisOpen == false)
                        {
                            OpenTurretUI();
                        }
                    }
                }
            }
        }
    }

    void OpenTurretUI()
    {
        TurretUIisOpen = true;
        gameObject.SetActive(true);
    }
    public void CloseTurretUI()
    {
        TurretUIisOpen = false;
        gameObject.SetActive(false);
    }

}
