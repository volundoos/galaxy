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
    
      
    public TurretData SelectedTurretData;

    [SerializeField] private string buildablePlace = "BuildablePlace";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    [SerializeField] private Toggle toggleRoundTurret, toggleRectTurret;

    private Transform _selection;


    private void ChangeInvisible(bool arg0)
    {
       if(toggleRoundTurret.isOn || toggleRectTurret.isOn)
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
        toggleRoundTurret.onValueChanged.AddListener(ChangeInvisible);
        toggleRectTurret.onValueChanged.AddListener(ChangeInvisible);
    }
    void Update()
    {
        if(_selection != null)
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
                        {
                        mapCube.BuildTurret(SelectedTurretData.turretPrefab);
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

}
