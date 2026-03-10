using UnityEngine;

public class RangeOnPlaceble : MonoBehaviour
{
    private bool isPlaceble;
    private float rangeNum;
    private float areaRangeNum = 5;

    private GameObject range;
    private GameObject placebleRange;
    [SerializeField] private GameObject rangePrefab;
    [SerializeField] private GameObject placebleRangePrefab;

    

    private void Start()
    {
        isPlaceble = PlaceTower.Instance.GetIsPlacable();
        rangeNum = this.gameObject.GetComponent<TowerRotateToEnemy>().GetRange();
        
    }
    private void Update()
    {
        if (isPlaceble)
        {
            if (range == null)
            {
                CreateShootingRange();

                CreateLimitingRange();

                isPlaceble = PlaceTower.Instance.GetIsPlacable();
            }
            else
            {
                range.SetActive(true);

                isPlaceble = PlaceTower.Instance.GetIsPlacable();
            }

        }
        else if (range != null 
            && range.activeSelf == true
            && !isPlaceble)
        {
            placebleRange.SetActive(false);
            range.SetActive(false);


            isPlaceble = PlaceTower.Instance.GetIsPlacable();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IsLimiterRange>())
        {
            placebleRange.SetActive(true);
        }
    }

    private void CreateShootingRange()
    {
        range = Instantiate(rangePrefab, transform.position, Quaternion.identity, this.gameObject.transform);
        range.transform.localScale = new Vector3(rangeNum, 0.1f, rangeNum);
    }
    private void CreateLimitingRange()
    {
        placebleRange = Instantiate(placebleRangePrefab, transform.position + new Vector3(0,0.1f,0), Quaternion.identity, this.gameObject.transform);
        placebleRange.transform.localScale = new Vector3(areaRangeNum, 0.2f, areaRangeNum);
        placebleRange.name = "PlacebleRange";
        placebleRange.SetActive(false);
    }

    public GameObject triggerRange()
    {
        return placebleRange;
    }

}
