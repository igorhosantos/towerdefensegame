using System;
using Assets.Script.engine.construction;
using Assets.Script.engine.construction.tower;
using UnityEngine;
using UnityEngine.UI;

public class CardConstructionView : MonoBehaviour
{
    [SerializeField] private ConstructionType constructionType;
    [SerializeField] private TowerBehaviourType towerBehaviour;
    [SerializeField] private Button button;
    [SerializeField] private Text title;
    [SerializeField] private Text description;

    public void Initiate(Action<ConstructionType> action)
    {
        button.onClick.AddListener(()=>action.Invoke(constructionType));

        switch (constructionType)
        {
            case ConstructionType.TowerDamageArea:
                title.text = "TOWER 1";
                break;
            case ConstructionType.TowerDamageCount:
                title.text = "TOWER 2";
                break;
            case ConstructionType.TowerSlowEffectArea:
                title.text = "TOWER 3";
                break;
            case ConstructionType.Wall:
                title.text = "WALL";
                description.text = "Block the enemies";
                break;
        }

        switch (towerBehaviour)
        {
            case TowerBehaviourType.DamageArea:
                description.text = "Damages all enemies in its range";
                break;
            case TowerBehaviourType.MultipleTargets:
                description.text = "Damages up to three enemies on the field";
                break;
            case TowerBehaviourType.SlowEffectArea:
                description.text = "Slows all enemies in its range";
                break;
        }
    }
}
