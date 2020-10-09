using System.Collections.Generic;
using UnityEngine;

public class HudView : MonoBehaviour
{
    [SerializeField] private List<CardConstructionView> cards;

    public delegate void HudCardEvent(ConstructionType constructionType);
    public static event HudCardEvent SummonedCard;

    void Awake()
    {
        cards.ForEach(c=>c.Initiate(SummonCard));
    }

    private void SummonCard(ConstructionType type)
    {
        SummonedCard?.Invoke(type);
    }


}
