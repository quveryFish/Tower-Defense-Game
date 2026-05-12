using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TWinfoPanel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject infoPanelRight;
    [SerializeField] private GameObject infoPanelLeft;
    [SerializeField] private List<GameObject> TWinfoSlotsRight;
    [SerializeField] private List<GameObject> TWinfoSlotsLeft;
    [SerializeField] private GameObject currentTW;
    [SerializeField] private Camera cam;

    private int TWid;
    private int TWlevel;
    private Sprite TWtowerImage;
    private int TWsellprice;

    private bool isPanelRight = false;

    private Ray ray;

    private void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                //Show Panel
                if (hit.collider.gameObject.GetComponent<TWinfo>()
                    && hit.collider.gameObject.GetComponent<TowerRotateToEnemy>().enabled == true)
                {
                    currentTW = hit.collider.gameObject;

                    TWid = hit.collider.gameObject.GetComponent<TWinfo>().id;
                    TWlevel = hit.collider.gameObject.GetComponent<TWinfo>().level;
                    TWtowerImage = hit.collider.gameObject.GetComponent<TWinfo>().towerImage;
                    TWsellprice = hit.collider.gameObject.GetComponent<TWinfo>().price;
                    if (currentTW.transform.position.x <= 0)
                    {
                        isPanelRight = true;
                        //infoPanelRight.SetActive(true);
                        //infoPanelLeft.SetActive(false);
                    }
                    else
                    {
                        isPanelRight = false;
                        //infoPanelRight.SetActive(false);
                        //infoPanelLeft.SetActive(true);
                    }
                    SetPanelInfo(isPanelRight);
                }

            }
        }
        
    }
    private void SetPanelInfo( bool WhatPanel)
    {
        if (WhatPanel)
        {
            infoPanelRight.SetActive(true);
            infoPanelLeft.SetActive(false);
            TWinfoSlotsRight[0].GetComponent<Image>().sprite = TWtowerImage;
            //TWinfoSlotsRight[1].GetComponentInChildren<Text>().text = "Upgrade ($"+upgPrice+")";
            TWinfoSlotsRight[2].GetComponentInChildren<Text>().text = $"Sell (${(int)(TWsellprice * 0.7f)})";

        }
        else
        {
            infoPanelRight.SetActive(false);
            infoPanelLeft.SetActive(true);
            TWinfoSlotsLeft[0].GetComponent<Image>().sprite = TWtowerImage;
            //TWinfoSlotsLeft[1].GetComponentInChildren<Text>().text = "Upgrade ($"+upgPrice+")";
            TWinfoSlotsLeft[2].GetComponentInChildren<Text>().text = $"Sell (${(int)(TWsellprice * 0.7f)})";
            Debug.Log((int)(TWsellprice * 0.7f));
            Debug.Log((TWsellprice * 0.7f));
        }
    }
    public void HidePanel()
    {
        currentTW = null;
        infoPanelRight.SetActive(false);
        infoPanelLeft.SetActive(false);
    }
    public void SellTW()
    {
        if (currentTW != null)
        {
            //Sell TW
            BankManager.Instance.AddMoney((int)(TWsellprice * (70 / 100f)));
            Destroy(currentTW);
            HidePanel();
        }
    }
    public void UpgradeTW()
    {
        if (currentTW != null)
        {
            //Upgrade TW
            currentTW.GetComponent<TWinfo>().level += 1;
            Debug.Log("new level" + currentTW.name);
            HidePanel();
        }
    }
}
