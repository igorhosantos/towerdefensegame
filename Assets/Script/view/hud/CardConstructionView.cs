using System;
using Assets.Script.engine.construction;
using UnityEngine;
using UnityEngine.UI;

public class CardConstructionView : MonoBehaviour
{
    [SerializeField] private ConstructionType constructionType;
    [SerializeField] private Button button;

 
    public void Initiate(Action<ConstructionType> action)
    {
        button.onClick.AddListener(()=>action.Invoke(constructionType));
    }
}
