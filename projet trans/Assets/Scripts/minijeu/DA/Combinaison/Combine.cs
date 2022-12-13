using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combine : MonoBehaviour
{
    private bool fini = false;
    public GameObject victor;

    private IndestructibleObject maJaugeValue;

    private bool activeTouch = false;
    public int isGoodPannel;

    public List<PannelPart> listPannel;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (fini == false)
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
            if (fini == false)
            {
                Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                fini = true;
                maJaugeValue.removeMJ(8, 2);
            }

            if (Input.touchCount > 0)
            {
                if (activeTouch == false)
                {
                    maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[8] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneDA");
                }
                activeTouch = true;
            }
            else { activeTouch = false; }
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
