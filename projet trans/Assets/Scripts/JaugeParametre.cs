using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaugeParametre : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;
    public RectTransform monTransform;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        monTransform.sizeDelta = new Vector2 (maJaugeValue.jaugeHype, 80);
    }
}
