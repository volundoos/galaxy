using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{

    public bool shopUIisOpen;
    public GameObject shopUI;
    [SerializeField] private CanvasGroup Shop;


    public TurretData Turret1Data;
    public TurretData Turret2Data;
    public TurretData Turret3Data;
    public TurretData Turret4Data;
    public TurretData Turret5Data;
    public TurretData Turret6Data;


    public TurretData SelectedTurretData;

    [SerializeField] private string buildablePlace = "BuildablePlace";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    [SerializeField] private Toggle sky1,sky2,sky3,ground1,ground2,ground3;

    private Transform _selection;

    public Text gold;
    public GameObject playerStat;

    private void ChangeInvisible(bool arg0)
    {
       if(sky1.isOn || sky2.isOn || sky3.isOn || ground1.isOn || ground2.isOn || ground3.isOn)
        {
            HideUI();
        }
    }

    private void HideUI()
    {
        Shop.alpha = 0f;
        Shop.interactable = false;
        Shop.blocksRaycasts = false;
    }

    private void Start()
    {
        shopUIisOpen = false;
        shopUI.SetActive(false);
        sky1.onValueChanged.AddListener(ChangeInvisible);
        sky2.onValueChanged.AddListener(ChangeInvisible);
        sky3.onValueChanged.AddListener(ChangeInvisible);
        ground1.onValueChanged.AddListener(ChangeInvisible);
        ground2.onValueChanged.AddListener(ChangeInvisible);
        ground3.onValueChanged.AddListener(ChangeInvisible);

    }
    void Update()
    {
        string goldString = gold.text.ToString();
        int.TryParse(goldString, out int goldNumber);

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        if (shopUI.activeSelf && Shop.alpha == 0f) 
        {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    //building turret
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    
                    if(Physics.Raycast(ray, out hit))
                    {
                        var selection = hit.transform;
                        if (selection.CompareTag(buildablePlace))
                        {
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if(selectionRenderer != null)
                            {
                                selectionRenderer.material = highlightMaterial;
                            }
                            _selection = selection;
                        }

                        MapCube mapCube = hit.collider.GetComponent<MapCube>();
                        if (Input.GetMouseButtonDown(0))
                        {if (goldNumber >= SelectedTurretData.cost)
                        {
                            mapCube.BuildTurret(SelectedTurretData.turretPrefab);
                            GoldManager goldManager = playerStat.GetComponent<GoldManager>();
                            goldManager.getGold(-SelectedTurretData.cost);
                        }
                        else
                        {
                            Debug.Log("not enough money");
                            mapCube.Show();
                        }
                        }
                    }                
                }
            }
    }
    public void OnTurret1Selected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = Turret1Data;
        }
    }

    public void OnTurret2Selected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = Turret2Data;
        }
    }

    public void OnTurret3Selected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = Turret3Data;
        }
    }

    public void OnTurret4Selected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = Turret4Data;
        }
    }

    public void OnTurret5Selected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = Turret5Data;
        }
    }

    public void OnTurret6Selected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = Turret6Data;
        }
    }
}
