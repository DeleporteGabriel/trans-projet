using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class texteDialogue : MonoBehaviour
{
    public List<string> mesDialogues;
    public TextMeshProUGUI monTexte;
    public int numeroDialogue = 0;
    private bool stayTouch = true;

    private int lettreAffiche = 0;
    private string textAffiche;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (textAffiche != mesDialogues[numeroDialogue])
        {
            textAffiche += mesDialogues[numeroDialogue][lettreAffiche];
        }
        lettreAffiche++;

        monTexte.text = textAffiche;

        if ((Input.touchCount > 0) && (stayTouch == false) && (textAffiche == mesDialogues[numeroDialogue]))
        {
            numeroDialogue = Mathf.Clamp(numeroDialogue + 1, 0, mesDialogues.Count - 1);

            stayTouch = true;

            textAffiche = "";
            lettreAffiche = 0;
        }
        if (Input.touchCount == 0)
        {
            stayTouch = false;
        }
    }
}
