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

    protected abstract void EndGame();
    
    protected virtual void Start()
    {
        GameFlow.NotifyWin += EndGame;
        GameFlow.NotifyLose += EndGame;
    }

    public void SelectMode()
    {
        if (renderer == null)
        {
            Debug.LogError("Construction needs to renderer : " + GetType().Name);
            return;
        }

        renderer.material.color = new Color(250, 250, 250, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(Gametag.CONSTRUCTION)) return;

        ValidSpot = false;
        status.UpdateStatus(ValidSpot);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(Gametag.CONSTRUCTION)) return;

        ValidSpot = true;
        status.UpdateStatus(ValidSpot);
    }

    public virtual void Place()
    {
        Placed = true;
        status.gameObject.SetActive(false);
    }

    protected virtual void OnDestroy()
    {
        GameFlow.NotifyWin -= EndGame;
        GameFlow.NotifyLose -= EndGame;
    }
   
}
