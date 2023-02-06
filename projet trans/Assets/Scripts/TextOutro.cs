using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOutro : MonoBehaviour
{
    [SerializeField]
    private List<string> mesDialogues;

    public TextMeshProUGUI monTexte;
    public int numeroDialogue = 0;
    private bool stayTouch = true;

    private int lettreAffiche = 0;
    private string textAffiche;

    private bool stopDialogue = false;

    private IndestructibleObject monTemps;
    // Start is called before the first frame update
    void Start()
    {
        monTemps = FindObjectOfType<IndestructibleObject>();
        if (Mathf.Floor(monTemps.tempsDeJeu_ % 60) < 10)
        {
            mesDialogues[5] = mesDialogues[5] + (Mathf.Floor(monTemps.tempsDeJeu_ / 60)).ToString() + ":0" + (Mathf.Floor(monTemps.tempsDeJeu_ % 60)).ToString();
        }
        else
        {
            mesDialogues[5] = mesDialogues[5] + (Mathf.Floor(monTemps.tempsDeJeu_ / 60)).ToString() + ":" + (Mathf.Floor(monTemps.tempsDeJeu_ % 60)).ToString();
        }

        mesDialogues[6] = mesDialogues[6] + monTemps.minijeuGagne.ToString() + " épreuves sur les 12 !";
    }

    // Update is called once per frame
    void Update()
    {
        if (stopDialogue == false)
        {
            if (textAffiche != mesDialogues[numeroDialogue])
            {
                textAffiche += mesDialogues[numeroDialogue][lettreAffiche];
            }
            lettreAffiche++;
        }
        if ((Input.touchCount > 0) && (stayTouch == false) && (textAffiche == mesDialogues[numeroDialogue]))
        {
            if (numeroDialogue == mesDialogues.Count - 1)
            {
                stopDialogue = true;
            }
            numeroDialogue = Mathf.Clamp(numeroDialogue + 1, 0, mesDialogues.Count - 1);

            textAffiche = "";
            lettreAffiche = 0;
        }
        else if ((Input.touchCount > 0) && (stayTouch == false))
        {
            textAffiche = mesDialogues[numeroDialogue];
        }
        if (stopDialogue == true) { textAffiche = ""; }
        monTexte.text = textAffiche;

        if (Input.touchCount == 0) { stayTouch = false; } else { stayTouch = true; }
    }
}
