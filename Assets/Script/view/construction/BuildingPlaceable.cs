
using UnityEditor.AI;
using UnityEngine;

public class BuildingPlaceable : MonoBehaviour
{
    private RaycastHit hit;
    private Vector3 movePoint;
    private ConstructionView prefab;
    private ConstructionView target;
    private bool enable;
    
    public void EnableNewConstruction(ConstructionView constructionView)
    {
        prefab = constructionView;
        target = Instantiate(prefab);
        target.SelectMode();
        enable = true;
    }

    void Awake()
    {
        NavMeshBuilder.BuildNavMesh();
    }

    void Start()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (!enable) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) 
        {
            target.transform.position = new Vector3(hit.point.x, target.transform.position.y, hit.point.z);
        }
    }

    void Update()
    {
        UpdatePosition();

        if (Input.GetMouseButton(0) && enable)
        {
            if (target.ValidSpot)
            {
                ConstructionView view = Instantiate(prefab, target.transform.position, target.transform.rotation,transform);
                view.Place();
                NavMeshBuilder.BuildNavMesh();
            }

            Destroy(target.gameObject);
            enable = false;
        }
    }
}
