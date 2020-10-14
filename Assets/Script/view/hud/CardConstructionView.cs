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
            case ConstructionType.TowerDamageCount:
            case ConstructionType.TowerDamageArea:
            case ConstructionType.TowerSlowEffectArea:
                title.text = "TORRE";
                break;
            case ConstructionType.Wall:
                title.text = "MURO";
                description.text = "Bloqueia os inimigos";
                break;
        }

        switch (towerBehaviour)
        {
            case TowerBehaviourType.DamageArea:
                description.text = "Dano em todos os inimigos em sua área";
                break;
            case TowerBehaviourType.MultipleTargets:
                description.text = "Danos em até 3 inimigos no campo";
                break;
            case TowerBehaviourType.SlowEffectArea:
                description.text = "Aplica lentidão em todos os inimigos em sua área";
                break;
        }
    }
}
