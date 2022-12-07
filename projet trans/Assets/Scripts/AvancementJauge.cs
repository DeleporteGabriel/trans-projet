using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvancementJauge : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;

    public CanvasRenderer cr;
    public Texture imageA;
    public Texture imageB;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
        maJaugeValue.ChangeJaugeHype();
    }

    // Update is called once per frame
    void Update()
    {
        if (maJaugeValue.minijeuTermines == 0)
        {
            cr.SetTexture(imageA);
        }
        else
        {
            cr.SetTexture(imageB);
        }
    }
}
