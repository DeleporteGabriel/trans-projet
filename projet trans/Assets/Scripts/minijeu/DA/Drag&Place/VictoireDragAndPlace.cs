using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoireDragAndPlace : MonoBehaviour
{
    private bool isTouch = false;

    [SerializeField]
    private VictoireDefaite maFin;

    private IndestructibleObject maJaugeValue;

    public int totalDrop;
    public int currentDrop;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
        if (Input.touchCount > 0) { isTouch = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if (maFin.debut == true || maFin.fini == true)
        {
            return;
        }

        if (totalDrop == currentDrop)
        {
            maFin.Victoire(9, 2);
        }
    }
}
