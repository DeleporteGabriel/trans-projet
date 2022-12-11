using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    private bool activeTouch = false;
    public int isGoodPannel;

    public List<PannelPart> listPannel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

                    if (targetObject.currentGraphics >= targetObject.graphics.Count)
                    {
                        targetObject.currentGraphics = 0;
                    }

                }
            }

            activeTouch = true;
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
            Debug.Log("bravo à tous");
        }
    }
}
