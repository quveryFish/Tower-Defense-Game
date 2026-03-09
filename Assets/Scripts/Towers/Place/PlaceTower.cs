using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject[] towers;
    [SerializeField] private GameObject currentTow;
    private Material currentMat;

    private bool isPlacable = false;

    private Ray ray;
    private RaycastHit hit;

    private void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaceTW();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && isPlacable)
        {
            isPlacable = false;
            SkinnedMeshRenderer[] renderers = currentTow.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer r in renderers)
            {
                r.material.color = Color.white;
                r.material = currentMat;
            }
            currentTow = null;
            currentMat = null;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && isPlacable)
        {
            isPlacable = false;
            Destroy(currentTow);
            currentTow = null;
            currentMat = null;
        }

        if (isPlacable && Physics.Raycast(ray, out hit))
        {
            currentTow.transform.position = hit.point;
        }
    }

    private void PlaceTW()
    {
        if (Physics.Raycast(ray, out hit))
        {
            currentTow = Instantiate(towers[0], hit.point, Quaternion.identity);
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
}