using System.Globalization;
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
        slider.maxValue = currentStatus;
        slider.value = currentStatus;
        fill.color = gradient.Evaluate(slider.maxValue);
        lifeLabel.text = currentStatus.ToString();
    }

    public void UpdateStatus(float currentUpdate)
    {
        Status += currentUpdate;
        if (Status < 0) Status = 0;

        slider.value = Status;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        lifeLabel.text = Status.ToString(CultureInfo.InvariantCulture);
    }
}
