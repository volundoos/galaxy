using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCube : MonoBehaviour
{
    [SerializeField] private CanvasGroup Shop;
    [SerializeField] private Toggle toggleRoundTurret, toggleRectTurret;

    [HideInInspector]
    public GameObject turretGO;//already existed
    Vector3 offset = new Vector3(0, 48, 0);



    public void BuildTurret(GameObject turretPrefab)
    {
        turretGO = GameObject.Instantiate(turretPrefab, transform.position + offset, Quaternion.identity);
        Show();
    }

    public void Show()
    {
        Shop.alpha = 1f;
        Shop.interactable = true;
        Shop.blocksRaycasts = true;

        toggleRoundTurret.isOn = false;
        toggleRectTurret.isOn = false;
    }
}
