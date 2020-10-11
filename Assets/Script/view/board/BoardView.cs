using System.Collections.Generic;
using Assets.Script.view.board;
using UnityEngine;

public class BoardView : MonoBehaviour
{
    
    [SerializeField] private BuildingPlaceable buildingPlaceable;
    [SerializeField] private List<ConstructionView> constructions;
    [SerializeField] private List<SpawnSpotView> spots;

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
