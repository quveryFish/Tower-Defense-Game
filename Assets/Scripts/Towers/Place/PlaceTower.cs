using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public static PlaceTower Instance;

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject[] towers;

    [SerializeField] private List<GameObject> placedTowerList = new List<GameObject>();
    [SerializeField] private GameObject currentTow;
    private Material currentMat;

    private bool isPlacable = false;

    private Ray ray;
    private RaycastHit hit;

    private void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowTW();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && isPlacable)
        {
                PlaceTW();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && isPlacable)
        {
            CancelPlaceTW();
        }

        if (isPlacable && Physics.Raycast(ray, out hit) && hit.collider.name == "Platform")
        {
            currentTow.transform.position = hit.point;
        }
    }

    


    private void ShowTW()
    {
        CancelPlaceTW();
        if (Physics.Raycast(ray, out hit) && hit.collider.name == "Platform")
        {
            EnableAllTriggerRanges(true);
            currentTow = Instantiate(towers[0], hit.point, Quaternion.identity, this.gameObject.transform);
            currentTow.transform.rotation = Quaternion.Euler(0, 180, 0);
            currentMat = currentTow.GetComponentInChildren<SkinnedMeshRenderer>().material;

            

            SkinnedMeshRenderer[] renderers = currentTow.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer r in renderers)
            {
                r.material.color = Color.red;
            }

            isPlacable = true;
        }
    }

    private void PlaceTW()
    {
        isPlacable = false;
        placedTowerList.Add(currentTow);
        SkinnedMeshRenderer[] renderers = currentTow.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer r in renderers)
        {
            r.material.color = Color.white;
            r.material = currentMat;
        }
        currentTow = null;
        currentMat = null;
        EnableAllTriggerRanges(false);
    }

    private void CancelPlaceTW()
    {
        isPlacable = false;
        if (currentTow == null) return;
        Destroy(currentTow);
        currentTow = null;
        currentMat = null;
        EnableAllTriggerRanges(false);
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

    public bool GetIsPlacable()
    {
        return isPlacable;
    }

}

