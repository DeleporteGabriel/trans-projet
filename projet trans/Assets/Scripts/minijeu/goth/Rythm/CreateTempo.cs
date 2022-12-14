using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateTempo : MonoBehaviour
{
    private bool fini = false;
    private bool debut = true;
    public GameObject victor;
    public GameObject intro;

    private GameObject monIntro;

    private IndestructibleObject maJaugeValue;

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

    [Range(1f, 3f)]
    public int nombreRangee;

    [Range(1f, 5f)]
    public int errorMax;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        variableTimer = Random.Range(1, 3);
        monIntro = Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (debut == true)
        {
            if (Input.touchCount > 0)
            {
                debut = false;
                Destroy(monIntro);
            }
            return;
        }

        timerTempo++;

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
                if ((rythmNumber > 19) && (errorCheck < errorMax))
                {
                    if (fini == false)
                    {
                        Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                        fini = true;
                        maJaugeValue.removeMJ(12, 4);
                    }

                    if (Input.touchCount > 0)
                    {
                        if (isTouch == false)
                        {
                            maJaugeValue.AugmenteJaugeValue(1f / 6f);
                            maJaugeValue.faitOuPasFait[12] = 1;
                            maJaugeValue.minijeuTermines++;
                            SceneManager.LoadScene("SceneGoth");
                        }
                        isTouch = true;
                    }
                    else { isTouch = false; }
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
