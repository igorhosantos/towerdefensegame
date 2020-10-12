using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private Text lifeLabel;

    public float Status { get; private set; }
    public void SetStatus(float currentStatus)
    {
        Status = currentStatus;
        slider.value = currentStatus;
        fill.color = gradient.Evaluate(1f);
        lifeLabel.text = currentStatus.ToString();
    }

    public void UpdateStatus(float currentUpdate)
    {
        if (currentUpdate < 0) currentUpdate = 0;

        Status = currentUpdate;
        slider.value = Status;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        lifeLabel.text = Status.ToString();
    }
}
