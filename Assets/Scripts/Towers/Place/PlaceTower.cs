using System;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public static PlaceTower Instance;

    [SerializeField] private LayerMask ground;
    [SerializeField] private GameObject mapLimiter;

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject[] towers;

    [SerializeField] private List<GameObject> placedTowerList = new List<GameObject>();
    [SerializeField] private GameObject currentTow;
    private int currentIndex = 0;
    private Material currentMat;

    private bool canBePlacable = false;
    private bool isButtonPressed = false;

    private int currentTWcost;

    private Ray ray;
    private RaycastHit hit;

   

    public event Action OnPlaceTower;

    public event Action OnShowTower;

    private void Start()
    {
        OnPlaceTower += PlaceTW;
        OnPlaceTower += () => BankManager.Instance.SubtractMoney(currentTWcost);

        OnShowTower += ShowTW;


        CancelPlaceTW();
    }
    private void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (isButtonPressed)
        {
            if (Physics.Raycast(ray, out hit, 1000, ground.value, QueryTriggerInteraction.Ignore))
            {
                OnShowTower?.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && canBePlacable && currentTow.GetComponent<RangeOnPlaceble>().GetCanPlace())
        {
            ButtonClickToTrue(currentTWcost);
            OnPlaceTower?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && canBePlacable)
        {
            CancelPlaceTW();
        }

        if (canBePlacable && Physics.Raycast(ray, out hit, 1000, ground.value, QueryTriggerInteraction.Ignore))// && hit.collider.name == "Platform")
        {
            currentTow.transform.position = hit.point;
        }
    }

    
    private void ShowTW()
    {
        BankManager.Instance.CheckIsEnough(currentTWcost);
        if (BankManager.Instance.CanAfford() == false)
        {
            Debug.Log("Can't afford tower!");
            isButtonPressed = false;
            return;
        }

        CancelPlaceTW();
        EnableAllTriggerRanges(true);

        currentTow = Instantiate(towers[currentIndex], hit.point, Quaternion.identity, this.gameObject.transform);
        currentTow.transform.rotation = Quaternion.Euler(0, 180, 0);
        if (currentTow.GetComponentInChildren<SkinnedMeshRenderer>() != null)
        {
            currentMat = currentTow.GetComponentInChildren<SkinnedMeshRenderer>().material;
        }
        else
        {
            currentMat = currentTow.GetComponentInChildren<MeshRenderer>().material;
        }
        BoolScriptsEnable(false);
        currentTow.GetComponent<TWinfo>().price = currentTWcost;



        canBePlacable = true;
        isButtonPressed = false;
    }

    private void PlaceTW()
    {
        canBePlacable = false;
        isButtonPressed = false;
        placedTowerList.Add(currentTow);

        SkinnedMeshRenderer[] renderers = currentTow.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer r in renderers)
        {
            r.material.color = Color.white;
            r.material = currentMat;
        }
        BoolScriptsEnable(true);
        currentTow = null;
        currentMat = null;
        EnableAllTriggerRanges(false);
    }

    private void CancelPlaceTW()
    {
        canBePlacable = false;
        isButtonPressed = false;
        if (currentTow == null) return;
        Destroy(currentTow);
        currentTow = null;
        currentMat = null;
        EnableAllTriggerRanges(false);
    }

    private void BoolScriptsEnable(bool isEnabled)
    {
        if (currentTow.GetComponent<TowerRotateToEnemy>() != null)
        {
            currentTow.GetComponent<TowerRotateToEnemy>().enabled = isEnabled;
        }
        if (currentTow.GetComponent<TowerShoot>() != null)
        {
            currentTow.GetComponent<TowerShoot>().enabled = isEnabled;
        }
        else if (currentTow.GetComponent<TowerSplashMelee>() != null)
        {
            currentTow.GetComponent<TowerSplashMelee>().enabled = isEnabled;
        }
    }
    private void EnableAllTriggerRanges(bool bl)
    {
        foreach (GameObject tower in placedTowerList)
        {
            if (tower.GetComponent<RangeOnPlaceble>().triggerRange() != null)
            {
                tower.GetComponent<RangeOnPlaceble>().triggerRange().SetActive(bl);
            }
        }
        mapLimiter.SetActive(bl);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool GetCanBePlacable()
    {
        return canBePlacable;
    }
    public void ButtonClickToTrue(int twCost)
    {
        currentTWcost = twCost;
        isButtonPressed = true;
    }
    public void SetCurrentIndex(int index)
    {
        currentIndex = index;
    }
    public void RemoveFromCurrentTWList(GameObject tower)
    {
        if (placedTowerList.Contains(tower))
        {
            placedTowerList.Remove(tower);
        }
    }

}

