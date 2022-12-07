using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconeColors : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;

    public SpriteRenderer sr;
    public int correspondanceMJ;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        switch (correspondanceMJ)
        {
            case 1: if (maJaugeValue.DragDrop != 0) { sr.color = Color.green; }; break;
            case 2: if (maJaugeValue.DragPlace != 0) { sr.color = Color.green; }; break;
            case 3: if (maJaugeValue.ColorsTest != 0) { sr.color = Color.green; }; break;
            case 4: if (maJaugeValue.Cibles != 0) { sr.color = Color.green; }; break;
            case 5: if (maJaugeValue.GyroSpace != 0) { sr.color = Color.green; }; break;
            case 6: if (maJaugeValue.ShakeBranlette != 0) { sr.color = Color.green; }; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
