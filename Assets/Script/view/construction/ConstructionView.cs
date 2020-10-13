using Assets.Script.engine.construction;
using Assets.Script.view.construction;
using Assets.Script.view.statics;
using UnityEngine;

public abstract class ConstructionView : MonoBehaviour
{
    [SerializeField] protected ConstructionType constructionType;
    [SerializeField] protected Renderer renderer;
    [SerializeField] protected BuildingStatus status;
    
    public ConstructionType ConstructionType => constructionType;
    public bool ValidSpot { get; private set; } = true;

    public bool Placed { get; protected set; }

    protected virtual void Start()
    {

    }

    public void SelectMode()
    {
        Color myColor = renderer.material.color;
        renderer.material.color = new Color(myColor.r, myColor.g, myColor.b, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Gametag.CONSTRUCTION))
        {
            ValidSpot = false;
            status.UpdateStatus(ValidSpot);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Gametag.CONSTRUCTION))
        {
            ValidSpot = true;
            status.UpdateStatus(ValidSpot);
        }
    }

    public void Place()
    {
        Placed = true;
        status.gameObject.SetActive(false);
    }
}
