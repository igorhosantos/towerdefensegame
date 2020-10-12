﻿using Assets.Script.view.construction;
using Assets.Script.view.statics;
using UnityEngine;

public class ConstructionView : MonoBehaviour
{
    [SerializeField] protected ConstructionType constructionType;
    [SerializeField] protected Renderer renderer;
    [SerializeField] protected BuildingStatus status;
    [SerializeField] protected AttackView constructionAttack;

    public ConstructionType ConstructionType => constructionType;
    public bool ValidSpot { get; private set; } = true;

    public void SelectMode()
    {
        Color myColor = renderer.material.color;
        renderer.material.color = new Color(myColor.r, myColor.g, myColor.b, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Gametag.CONSTRUCTION))
        {
            ValidSpot = false;
            status.UpdateStatus(ValidSpot);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Gametag.CONSTRUCTION))
        {
            ValidSpot = true;
            status.UpdateStatus(ValidSpot);
        }
    }

    public void Place()
    {
        status.gameObject.SetActive(false);
    }
}
