using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TWinfoPanel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject infoPanelRight;
    [SerializeField] private GameObject infoPanelLeft;
    [SerializeField] private GameObject bgCloseButton;
    [SerializeField] private List<GameObject> TWinfoSlotsRight;
    [SerializeField] private List<GameObject> TWinfoSlotsLeft;
    [SerializeField] private GameObject currentTW;
    [SerializeField] private Camera cam;

    private int TWlevel;
    private Sprite TWtowerImage;
    private int TWsellprice;
    private int currentUpgPrice;

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

                    TWlevel = currentTW.GetComponent<TWinfo>().level;
                    TWtowerImage = currentTW.GetComponent<TWinfo>().towerImage;
                    TWsellprice = currentTW.GetComponent<TWinfo>().price;

                    if (currentTW.GetComponent<TWinfo>().level < currentTW.GetComponent<TWinfo>().towerUpgradesList.Count)
                    {
                        currentUpgPrice = currentTW.GetComponent<TWinfo>().towerUpgradesList[currentTW.GetComponent<TWinfo>().level].upgCost;
                    }

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
        //right panel
        if (WhatPanel)
        {
            infoPanelRight.SetActive(true);
            infoPanelLeft.SetActive(false);
            TWinfoSlotsRight[0].GetComponent<Image>().sprite = TWtowerImage;
            UpdateTextRight();
            GetComponentInChildren<TwStats>().ClearUpg();
            bgCloseButton.SetActive(true);
        }
        //left panel
        else
        {
            infoPanelRight.SetActive(false);
            infoPanelLeft.SetActive(true);
            TWinfoSlotsLeft[0].GetComponent<Image>().sprite = TWtowerImage;
            UpdateTextLeft();
            GetComponentInChildren<TwStats>().ClearUpg();
            bgCloseButton.SetActive(true);
        }
        currentTW.GetComponent<RangeOnPlaceble>().SetIsUpgradable(true);
        currentTW.GetComponent<RangeOnPlaceble>().ShowShootRange(true);
    }
    private void UpdateTextRight()
    {
        TWsellprice = currentTW.GetComponent<TWinfo>().price;

        if (currentTW.GetComponent<TWinfo>().level < currentTW.GetComponent<TWinfo>().towerUpgradesList.Count)
        {
            currentUpgPrice = currentTW.GetComponent<TWinfo>().towerUpgradesList[currentTW.GetComponent<TWinfo>().level].upgCost;
        }

        if (currentTW.GetComponent<TWinfo>().level >= currentTW.GetComponent<TWinfo>().towerUpgradesList.Count)
        {
            TWinfoSlotsRight[1].GetComponentInChildren<Text>().text = "Upgrade (Max)";
        }
        else
        {
            TWinfoSlotsRight[1].GetComponentInChildren<Text>().text =
                "Upgrade ($" + currentUpgPrice + ")";
        }
        TWinfoSlotsRight[2].GetComponentInChildren<Text>().text = $"Sell (${(int)(TWsellprice * 0.7f)})";
    }
    private void UpdateTextLeft()
    {
        TWsellprice = currentTW.GetComponent<TWinfo>().price;

        if (currentTW.GetComponent<TWinfo>().level < currentTW.GetComponent<TWinfo>().towerUpgradesList.Count)
        {
            currentUpgPrice = currentTW.GetComponent<TWinfo>().towerUpgradesList[currentTW.GetComponent<TWinfo>().level].upgCost;
        }

        if (currentTW.GetComponent<TWinfo>().level >= currentTW.GetComponent<TWinfo>().towerUpgradesList.Count)
        {
            TWinfoSlotsLeft[1].GetComponentInChildren<Text>().text = "Upgrade (Max)";
        }
        else
        {
            TWinfoSlotsLeft[1].GetComponentInChildren<Text>().text =
                "Upgrade ($" + currentUpgPrice + ")";
        }
        TWinfoSlotsLeft[2].GetComponentInChildren<Text>().text = $"Sell (${(int)(TWsellprice * 0.7f)})";
    }
    public void HidePanel()
    {
        currentTW.GetComponent<RangeOnPlaceble>().SetIsUpgradable(false);
        currentTW = null;
        infoPanelRight.SetActive(false);
        infoPanelLeft.SetActive(false);
        bgCloseButton.SetActive(false);
    }
    public void SellTW()
    {
        if (currentTW != null)
        {
            //Sell TW
            BankManager.Instance.AddMoney((int)(TWsellprice * (70 / 100f)));
            PlaceTower.Instance.RemoveFromCurrentTWList(currentTW);
            Destroy(currentTW);
            HidePanel();
        }
    }
    public void UpgradeTW()
    {
        if (currentTW != null && BankManager.Instance.isEnoughMoney(currentUpgPrice)
            )
        {
            //Upgrade TW
            if (currentTW.GetComponent<TWinfo>().level >= currentTW.GetComponent<TWinfo>().towerUpgradesList.Count)
            {
                Debug.Log("Max level reached");

                return;
            }
            currentTW.GetComponent<TWinfo>().level += 1;
            BankManager.Instance.SubtractMoney(currentUpgPrice);
            currentTW.GetComponent<TWinfo>().Upgrade();
            GetComponentInChildren<TwStats>().ClearUpg();
            UpdateTextRight();
            UpdateTextLeft();
            //HidePanel();
        }
    }

    public TWinfo GetCurrentTW()
    {
        return currentTW.GetComponent<TWinfo>();
    }
}
