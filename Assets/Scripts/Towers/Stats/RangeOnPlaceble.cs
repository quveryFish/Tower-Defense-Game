using UnityEngine;

public class RangeOnPlaceble : MonoBehaviour
{
    [SerializeField]private float areaRangeNum = 5;
    [SerializeField]private bool needRange = true;
    private bool canBePlaceble;
    private float rangeNum;
    private SkinnedMeshRenderer[] renderers;
    private bool isUpgradable;

    private GameObject range;
    private GameObject placebleRange;
    [SerializeField] private GameObject rangePrefab;
    [SerializeField] private GameObject placebleRangePrefab;

    private bool canPlace = true;
    private int overlapCount = 0;

    private void Start()
    {
        renderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        isUpgradable = false;
        canBePlaceble = PlaceTower.Instance.GetCanBePlacable();
        if (needRange == true)
        {
            rangeNum = this.gameObject.GetComponent<TowerRotateToEnemy>().GetRange();
        }
        
    }
    private void Update()
    {
        if (canBePlaceble)
        {
            if (range == null)
            {
                if (needRange == true)
                {
                    CreateShootingRange();
                }

                CreateLimitingRange();

                canBePlaceble = PlaceTower.Instance.GetCanBePlacable();
            }
            else
            {
                range.SetActive(true);

                canBePlaceble = PlaceTower.Instance.GetCanBePlacable();
            }

        }
        else if (range != null 
            && range.activeSelf == true
            && !canBePlaceble && isUpgradable == false)
        {
            placebleRange.SetActive(false);
            //Debug.Log("Range deactivated");
            range.SetActive(false);


            canBePlaceble = PlaceTower.Instance.GetCanBePlacable();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<IsLimiterRange>())
        {
            overlapCount++;
            //Debug.Log("Overlap count: " + overlapCount);
            if (overlapCount > 0 && canBePlaceble)
            {
                canPlace = false;
                if (renderers != null)
                {
                    foreach (SkinnedMeshRenderer r in renderers)
                    {
                        r.material.color = Color.orange;
                    }
                }
                //Debug.Log("Cannot place tower here! Overlap count: " + overlapCount);
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<IsLimiterRange>())
        {
            overlapCount--;
            if (overlapCount <= 0 && canBePlaceble)
            {
                canPlace = true;
                foreach (SkinnedMeshRenderer r in renderers)
                {
                    r.material.color = Color.green;
                }
            }
        }
    }

    private void CreateShootingRange()
    {
        range = Instantiate(rangePrefab, transform.position, Quaternion.identity, this.gameObject.transform);
        range.transform.localScale = new Vector3(rangeNum * 2, 0.1f, rangeNum * 2);
    }
    private void CreateLimitingRange()
    {
        placebleRange = Instantiate(placebleRangePrefab, transform.position + new Vector3(0,0.1f,0), Quaternion.identity, this.gameObject.transform);
        placebleRange.transform.localScale = new Vector3(areaRangeNum / 2.5f, 0.2f, areaRangeNum / 2.5f); 
        placebleRange.name = "PlacebleRange";
        placebleRange.SetActive(false);
    }

    public GameObject triggerRange()
    {
        return placebleRange;
    }
    public void StretchRange(float newRange)
    { if (range != null)
        {
            rangeNum = newRange;
            range.transform.localScale = new Vector3(rangeNum * 2, 0.1f, rangeNum * 2);
        }
    }
    public void ShowShootRange(bool isEnabled)
    {
        if (range != null)
        {
            range.SetActive(isEnabled);
        }
    }
    public bool GetCanPlace()
    {
        return canPlace;
    }
    public void SetIsUpgradable(bool value)
    {
        isUpgradable = value;
    }

}
