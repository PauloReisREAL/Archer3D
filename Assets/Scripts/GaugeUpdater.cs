using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeUpdater : MonoBehaviour
{
    public Image fillableImage;

    public void UpdateGauge (float currentValue, float maxValue)
    {
        fillableImage.fillAmount = currentValue / maxValue;
    }
}
