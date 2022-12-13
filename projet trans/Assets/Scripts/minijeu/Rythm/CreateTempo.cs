using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTempo : MonoBehaviour
{
    public bool isTouch = false;

    public int tempoTotal;
    public int errorCheck;

    public float delaisTempo;
    public int timerTempo;
    private int noteNumber = 1;
    public CreateTempo self;


    public int rythmNumber = 0;

    public int variableTimer;

    public TempoRythm maNote;
    // Start is called before the first frame update
    void Start()
    {
        variableTimer = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        timerTempo++;

        if ((timerTempo > variableTimer * delaisTempo) && (tempoTotal != noteNumber - 1))
        {
            variableTimer = Random.Range(1, 3);
            timerTempo = 0;

            TempoRythm noteTempo = Instantiate(maNote, new Vector3(3, 3, 0), Quaternion.identity);
            noteTempo.IDchecker = self;
            noteTempo.noteID = noteNumber;
            noteNumber++;
        }

        if (errorCheck >= 3)
        {
            Debug.Log("défaite");
        }

        if (Input.touchCount > 0)
        {
            if (isTouch == false)
            {
                rythmNumber++;
                if ((rythmNumber > 19) && (errorCheck < 3))
                {
                    Debug.Log("victoire !");
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
