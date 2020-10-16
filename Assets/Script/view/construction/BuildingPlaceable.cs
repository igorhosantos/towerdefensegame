using UnityEngine;
using UnityEngine.AI;

public class BuildingPlaceable : MonoBehaviour
{
    [SerializeField] private float gridSize = 0.5f;

    private Vector3 movePoint;
    private ConstructionView prefab;
    private ConstructionView target;
    private bool enable;
    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }
    public void EnableNewConstruction(ConstructionView constructionView)
    {
        prefab = constructionView;
        target = Instantiate(prefab);
        target.SelectMode();
        enable = true;
    }

    private void UpdatePosition()
    {
        if (!enable) return;

        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) 
        {
            Vector3 pos = new Vector3(Mathf.RoundToInt(hit.point.x/gridSize)* gridSize,
                                        Mathf.RoundToInt(target.transform.position.y),
                                        Mathf.RoundToInt(hit.point.z / gridSize) * gridSize);

            target.transform.position = pos;
        }
    }

    void Update()
    {
        UpdatePosition();

        if (Input.GetMouseButton(0) && enable)
        {
            if (target.ValidSpot)
            {
                ConstructionView view = Instantiate(prefab, target.transform.position, target.transform.rotation, transform);
                view.Place();
            }

            CancelConstruction();
        }
        else if (Input.GetMouseButton(1) && enable)
        {
            CancelConstruction();
        }
    }

    private void CancelConstruction()
    {
        Destroy(target.gameObject);
        enable = false;
    }

}
