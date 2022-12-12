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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * vitesseRythm;

        if (tempoState == 2)
        {
            sr.color = Color.red;
            IDchecker.rythmNumber++;
            IDchecker.errorCheck++;
            tempoState++;
        }

        if (transform.position.x < -2.3f)
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
                        sr.color = Color.red;
                        IDchecker.errorCheck++;
                        tempoState = 3;
                    }
                }
                else if (tempoState == 1)
                {
                    if ((sr.color != Color.red) && (IDchecker.rythmNumber == noteID))
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
