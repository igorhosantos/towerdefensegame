using UnityEngine;

public class BoardView : MonoBehaviour
{
    [SerializeField] private BuildingPlaceable buildingPlaceable;

    void Awake()
    {
        HudView.SummonedCard += OnSummonConstruction;
    }

    private void OnSummonConstruction(ConstructionType type)
    {
        Debug.LogWarning("Create : " + type);
        buildingPlaceable.EnableNewConstruction();
    }
}
