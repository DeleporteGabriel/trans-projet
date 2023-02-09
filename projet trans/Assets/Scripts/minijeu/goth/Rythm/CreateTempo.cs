using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateTempo : MonoBehaviour
{
    [SerializeField]
    private VictoireDefaite maFin;

    private IndestructibleObject maJaugeValue;

    public bool isTouch = false;

    public int tempoTotal;
    public int errorCheck;

    public float delaisTempo;
    public float timerTempo;
    private int noteNumber = 1;
    public CreateTempo self;


    public int rythmNumber = 0;

    public int variableTimer;

    public TempoRythm maNote;

    public int nombreRangee;

    public int errorMax;

    private int diffulctLevel;
    private float vitesseNote;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
        if (maJaugeValue != null) { diffulctLevel = maJaugeValue.difficulty; } else { diffulctLevel = 3; }

        if (diffulctLevel == 1)
        {
            errorMax = 5;
            nombreRangee = 1;
            vitesseNote = 1;
        }
        else if (diffulctLevel == 2)
        {
            errorMax = 3;
            nombreRangee = 2;
            vitesseNote = 1.2f;
        }
        else if (diffulctLevel == 3)
        {
            errorMax = 0;
            nombreRangee = 3;
            vitesseNote = 1.5f;
        }

        variableTimer = Random.Range(1, 3);
        if (Input.touchCount > 0) { isTouch = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if (maFin.debut == true || maFin.fini == true)
        {
            return;
        }

        timerTempo += Time.deltaTime;

        if ((timerTempo > variableTimer * delaisTempo) && (tempoTotal != noteNumber - 1))
        {
            variableTimer = Random.Range(1, 3);
            timerTempo = 0;

            var tempTypeNote = Random.Range(0, nombreRangee);
            var tempPosition = 0f;

            switch (tempTypeNote)
            {
                case 0: tempPosition = -1.5f;  break;
                case 1: tempPosition = 0;  break;
                case 2: tempPosition = 1.5f; break;
            }

            TempoRythm noteTempo = Instantiate(maNote, new Vector3(tempPosition, -4.4f, 0), Quaternion.identity);
            noteTempo.sr.sprite = noteTempo.noteSkin[tempTypeNote];
            noteTempo.vitesseRythm *= vitesseNote;

            noteTempo.IDchecker = self;
            noteTempo.noteID = noteNumber;
            noteNumber++;
        }

        if (errorCheck > errorMax)
        {
            maFin.Defaite(13, 4);

            if (Input.touchCount > 0)
            {
                if (isTouch == false)
                {
                    //maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[13] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneGoth");
                }
            }
        }

        if ((rythmNumber > 19) && (errorCheck <= errorMax))
        {
            maFin.Victoire(13, 4);
        }

        if (Input.touchCount > 0)
        {
            if (isTouch == false)
            {
                if (rythmNumber+1 < noteNumber)
                {
                    rythmNumber++;
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
