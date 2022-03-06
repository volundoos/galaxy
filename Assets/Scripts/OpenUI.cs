using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenUI : MonoBehaviour
{
    public GameObject ShopUI;
    public bool ShopUIisOpen;

    [SerializeField] private string station = "Station";
    // Start is called before the first frame update
    void Start()
    {
        ShopUI.SetActive(false);
        ShopUIisOpen = false;
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
                    if (hit.transform.CompareTag(station))
                    {
                        if (ShopUIisOpen == false)
                        {
                            OpenShopUI();
                        }
                    }
                }
            }
        }
    }
    void OpenShopUI()
    {
        ShopUIisOpen = true;
        Vector3 mousePos = Input.mousePosition;
        Vector3 uiPos = new Vector3(mousePos.x-200, mousePos.y);
        ShopUI.SetActive(true);
        ShopUI.transform.position = uiPos;
    }

    public void CloseShopUI()
    {
        ShopUIisOpen = false;
        ShopUI.SetActive(false);
    }
}
