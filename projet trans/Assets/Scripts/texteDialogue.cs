using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class texteDialogue : MonoBehaviour
{
    private IndestructibleObject monMiniJeuChecker;

    public List<string> mesDialoguesA;
    public List<string> mesDialoguesB;
    public List<string> mesDialoguesC;
    public List<string> mesDialoguesD;
    public List<string> mesDialoguesE;
    public List<string> mesDialoguesF;

    private List<string> mesDialogues;

    public TextMeshProUGUI monTexte;
    public int numeroDialogue = 0;
    private bool stayTouch = true;

    private int lettreAffiche = 0;
    private string textAffiche;

    public string nextSceneA;
    public string nextSceneB;

    public GameObject mesOptions;

    private bool stopDialogue = false;

    public int monPerso;
    private int monMiniJeu;
    // Start is called before the first frame update
    void Start()
    {
        monMiniJeuChecker = FindObjectOfType<IndestructibleObject>();

        if (monPerso != -1)
        {
            for (int i = 0; i <= monMiniJeuChecker.currentMJ.Count - 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (monMiniJeuChecker.currentMJ[i] == monMiniJeuChecker.mesPersos[monPerso][j])
                    {
                        //récupère la valeur du mj
                        monMiniJeu = monMiniJeuChecker.currentMJ[i] - 1;
                        nextSceneA = monMiniJeuChecker.mesMinijeux[monMiniJeu];

                        switch (j)
                        {
                            case 0 : mesDialogues = mesDialoguesA; break;
                            case 1: mesDialogues = mesDialoguesC; break;
                            case 2: mesDialogues = mesDialoguesE; break;
                        }
                    }
                }
            }
        }

        if (mesDialogues == null)
        {
            mesDialogues = mesDialoguesB;
        }
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
                if (mesDialogues == mesDialoguesA || mesDialogues == mesDialoguesC || mesDialogues == mesDialoguesE)
                {
                    Instantiate(mesOptions, new Vector3(-1f, -0.6f, -1), Quaternion.identity);
                    var nextMJ = Instantiate(mesOptions, new Vector3(1, -0.6f, -1), Quaternion.identity);
                    nextMJ.GetComponent<SwitchScene>().sr.sprite = nextMJ.GetComponent<SwitchScene>().spriteValide;
                    nextMJ.GetComponent<SwitchScene>().maScene = nextSceneA;
                }
                else
                {
                    SceneManager.LoadScene(nextSceneB);
                }

            }
            numeroDialogue = Mathf.Clamp(numeroDialogue + 1, 0, mesDialogues.Count - 1);

            stayTouch = true;

            textAffiche = "";
            lettreAffiche = 0;
        }
        if (stopDialogue == true) { textAffiche = ""; }
        monTexte.text = textAffiche;

        if (Input.touchCount == 0) { stayTouch = false; }
    }
}
