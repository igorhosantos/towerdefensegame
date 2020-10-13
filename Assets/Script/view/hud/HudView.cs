using System.Collections.Generic;
using Assets.Script.engine.construction;
using UnityEngine;
using UnityEngine.UI;

public class HudView : MonoBehaviour
{
    [SerializeField] private List<CardConstructionView> cards;
    [SerializeField] private Text statusLabel;

    public delegate void HudCardEvent(ConstructionType constructionType);
    public static event HudCardEvent SummonedCard;

    void Awake()
    {
        HideStatus();
        cards.ForEach(c=>c.Initiate(SummonCard));

        GameFlow.NotifyStart += StartAlert;
        GameFlow.NotifyLose += LoseAlert;
        GameFlow.NotifyWin += WinAlert;
    }

    private void HideStatus()
    {
        statusLabel.gameObject.SetActive(false);
    }

    private void StartAlert()
    {
        statusLabel.text = "Start!";
        statusLabel.gameObject.SetActive(true);

        Invoke(nameof(HideStatus),1f);
    }
    private void LoseAlert()
    {
        statusLabel.text = "You Lose!";
        statusLabel.gameObject.SetActive(true);
    }
    private void WinAlert()
    {
        statusLabel.text = "You Win!";
        statusLabel.gameObject.SetActive(true);
    }


    private void SummonCard(ConstructionType type)
    {
        SummonedCard?.Invoke(type);
    }


}
