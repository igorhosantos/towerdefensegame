using Assets.Script.view.statics;
using UnityEngine;

public class ConstructionView : MonoBehaviour
{
    [SerializeField] protected ConstructionType constructionType;

    public bool ValidSpot { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Collide: " + other.gameObject.name);
        if (other.gameObject.CompareTag(Gametag.CONSTRUCTION))
        {
            ValidSpot = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ValidSpot = true;
    }
}
