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

    private int diffulctLevel;
    [SerializeField]
    private TimerDefeat monTimer;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        diffulctLevel = maJaugeValue.difficulty;

        if (diffulctLevel == 1)
        {
            monTimer.timerMax *= 1;
            monTimer.currentTimer = monTimer.timerMax;
        }
        else if (diffulctLevel == 2)
        {
            monTimer.timerMax *= 0.8f;
            monTimer.currentTimer = monTimer.timerMax;
        }
        else if (diffulctLevel == 3)
        {
            monTimer.timerMax *= 0.5f;
            monTimer.currentTimer = monTimer.timerMax;
        }

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
