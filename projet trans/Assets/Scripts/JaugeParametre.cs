using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaugeParametre : MonoBehaviour
{
    public Image img;
    public void UpdateJauge(float value)
    {
        img.fillAmount = value;
    }
}
