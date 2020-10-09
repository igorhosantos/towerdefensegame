using System.Collections.Generic;
using UnityEngine;

public class BoardView : MonoBehaviour
{
    [SerializeField] private BuildingPlaceable buildingPlaceable;
    [SerializeField] private List<ConstructionView> constructions;

    void Awake()
    {
        HudView.SummonedCard += OnSummonConstruction;
    }

    private void OnSummonConstruction(ConstructionType type)
    {
        buildingPlaceable.EnableNewConstruction(GetConstructionByType(type));
    }

    private ConstructionView GetConstructionByType(ConstructionType type)
    {
        return constructions.Find(c => c.ConstructionType == type);
    }
}
