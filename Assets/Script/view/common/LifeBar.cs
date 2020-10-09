using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    public float Status { get; private set; }
    public void SetStatus(float currentStatus)
    {
        Status = currentStatus;
        slider.value = currentStatus;

        fill.color = gradient.Evaluate(1f);
    }

    public void UpdateStatus(float currentUpdate)
    {
        Status += currentUpdate;
        slider.value = Status;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
