using System;
using Assets.Script.engine.construction;
using UnityEngine;
using UnityEngine.UI;

public class CardConstructionView : MonoBehaviour
{
    [SerializeField] private ConstructionType constructionType;
    [SerializeField] private Button button;
    [SerializeField] private Text label;

 
    public void Initiate(Action<ConstructionType> action)
    {
        label.text = constructionType.ToString();
        button.onClick.AddListener(()=>action.Invoke(constructionType));
    }
}
