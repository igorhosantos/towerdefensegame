using System.Collections.Generic;
using Assets.Script.engine.construction;
using Assets.Script.view.board;
using Assets.Script.view.enemy;
using Assets.Script.view.mainspot;
using UnityEngine;

public class BoardView : MonoBehaviour
{
    
    [SerializeField] private MainSpotView mainSpot;
    [SerializeField] private BuildingPlaceable buildingPlaceable;
    [SerializeField] private List<ConstructionView> constructions;
    [SerializeField] private List<SpawnSpotView> spots;
    [SerializeField] private List<EnemyView> enemiesConfig;

    void Awake()
    {
        HudView.SummonedCard += OnSummonConstruction;
        GameFlow.NotifyNewWave += OnNewWave;
    }

    private void OnSummonConstruction(ConstructionType type)
    {
        buildingPlaceable.EnableNewConstruction(GetConstructionByType(type));
    }

    private void OnNewWave(List<WaveMembers> members, int spawnId)
    {
        var spot = spots.Find(sp => sp.Id == spawnId).transform;
        members.ForEach(mb =>
        {
            for (var i = 0; i < mb.Amount; i++)
            {
                Instantiate(GetEnemyByType(mb.EnemyType), 
                    spot.position,spot.rotation,transform)
                    .StartEnemy(mainSpot);
            }
        });
    }

    private ConstructionView GetConstructionByType(ConstructionType type)
    {
        return constructions.Find(c => c.ConstructionType == type);
    }

    private EnemyView GetEnemyByType(EnemyType enemyType)
    {
        return enemiesConfig.Find(e => e.EnemyType == enemyType);
    }
}
