using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCube : MonoBehaviour
{
    [SerializeField] private CanvasGroup Shop;
    [SerializeField] public Toggle sky1, sky2, sky3, ground1, ground2, ground3;

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

        sky1.isOn = false;
        sky2.isOn = false;
        sky3.isOn = false;
        ground1.isOn = false;
        ground2.isOn = false;
        ground3.isOn = false;
    }
}
