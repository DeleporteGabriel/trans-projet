using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoRythm : MonoBehaviour
{
    private bool isTouch = false;

    public float vitesseRythm;
    public int tempoState;
    public SpriteRenderer sr;
    public int noteID;

    public CreateTempo IDchecker;
    public List<Sprite> noteSkin;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * vitesseRythm;

        if (tempoState == 2)
        {
            sr.sprite = noteSkin[3];
            IDchecker.rythmNumber++;
            IDchecker.errorCheck++;
            tempoState++;
        }

        if (transform.position.y > 5.6f)
        {
            if (tempoState != 3)
            {
                tempoState = 2;
            }
        }

        if (Input.touchCount > 0)
        {
            if (isTouch == false)
            {
                if (tempoState == 0)
                {
                    if (IDchecker.rythmNumber == noteID)
                    {
                        sr.sprite = noteSkin[3];
                        IDchecker.errorCheck++;
                        tempoState = 3;
                    }
                }
                else if (tempoState == 1)
                {
                    if ((sr.sprite = noteSkin[3]) && (IDchecker.rythmNumber == noteID))
                    {
                        sr.enabled = false;
                        tempoState = 3;
                    }
                }
            }
            isTouch = true;
        }
        else
        {
            isTouch = false;
        }
    }
}
