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
    public GameObject defat;

    private GameObject monIntro;

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

    [Range(1f, 3f)]
    public int nombreRangee;

    [Range(1f, 5f)]
    public int errorMax;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        variableTimer = Random.Range(1, 3);
        monIntro = Instantiate(intro, new Vector3(0, 1, 0), Quaternion.identity);
        if (Input.touchCount > 0) { isTouch = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if (debut == true)
        {
            if (Input.touchCount > 0 && isTouch == false)
            {
                debut = false;
                Destroy(monIntro);
                isTouch = true;
            }

            if (Input.touchCount == 0) { isTouch = false; }
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

            noteTempo.IDchecker = self;
            noteTempo.noteID = noteNumber;
            noteNumber++;
        }

        if (errorCheck >= 3)
        {
            if (fini == false)
            {
                Instantiate(defat, new Vector3(0, 1, 0), Quaternion.identity);
                maJaugeValue.isMinigameWin = false;
                fini = true;
                maJaugeValue.removeMJ(13, 4);
            }

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

        if ((rythmNumber > 19) && (errorCheck < errorMax))
        {
            if (fini == false)
            {
                Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                maJaugeValue.isMinigameWin = true;
                fini = true;
                maJaugeValue.removeMJ(13, 4);
            }

            if (Input.touchCount > 0)
            {
                if (isTouch == false)
                {
                    maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[13] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneGoth");
                }
                isTouch = true;
            }
            else { isTouch = false; }
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
