using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combine : MonoBehaviour
{

    [SerializeField]
    private VictoireDefaite maFin;

    private IndestructibleObject maJaugeValue;

    private bool activeTouch = false;
    public int isGoodPannel;

    public List<PannelPart> listPannel;

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

        if (Input.touchCount > 0) { activeTouch = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if (maFin.debut == true || maFin.fini == true)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            var tempPosition = Input.touches[0].position;

            var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
            if (Physics.Raycast(tempRay, out var other) && activeTouch == false)
            {
                if (other.collider.GetComponent<PannelPart>() != null)
                {
                    var targetObject = other.collider.GetComponent<PannelPart>();
                    targetObject.currentGraphics++;
                    targetObject.onTapTrigger();
                    activeTouch = true;

                    if (targetObject.currentGraphics >= targetObject.graphics.Count)
                    {
                        targetObject.currentGraphics = 0;
                    }

                }
            }
        }
        else
        {
            activeTouch = false;
        }

        isGoodPannel = 0;
        for (var i = 0; i < listPannel.Count; i++)
        {
            if (listPannel[i].currentGraphics == listPannel[i].rightPannel)
            {
                isGoodPannel++;
            }
        }

        if (isGoodPannel == listPannel.Count)
        {
            maFin.Victoire(8, 2);
        }

        if (Input.touchCount > 0)
        {
            activeTouch = true;
        }
        else
        {
            activeTouch = false;
        }
    } 
}
