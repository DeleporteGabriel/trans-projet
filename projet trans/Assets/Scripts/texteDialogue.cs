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

    private List<string> mesDialogues;

    public TextMeshProUGUI monTexte;
    public int numeroDialogue = 0;
    private bool stayTouch = true;

    private int lettreAffiche = 0;
    private string textAffiche;

    public string nextSceneA;
    public string nextSceneB;

    private string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        monMiniJeuChecker = FindObjectOfType<IndestructibleObject>();

        #region Light Girl
        if (SceneManager.GetActiveScene().name == "SceneLightGirl")
        {
            if (monMiniJeuChecker.DragDrop == 0)
            {
                mesDialogues = mesDialoguesA;
                nextScene = nextSceneA;
            }
            else if (monMiniJeuChecker.DragDrop == 1)
            {
                mesDialogues = mesDialoguesB;
                nextScene = nextSceneB;
            }
        }
        #endregion
        #region Benevol
        else if (SceneManager.GetActiveScene().name == "SceneBenevol")
        {
            if (monMiniJeuChecker.Cibles == 0)
            {
                mesDialogues = mesDialoguesA;
                nextScene = nextSceneA;
            }
            else if (monMiniJeuChecker.Cibles == 1)
            {
                mesDialogues = mesDialoguesB;
                nextScene = nextSceneB;
            }
        }
        #endregion
        #region Goth
        else if (SceneManager.GetActiveScene().name == "SceneGoth")
        {
            if (monMiniJeuChecker.DragPlace == 0)
            {
                mesDialogues = mesDialoguesA;
                nextScene = nextSceneA;
            }
            else if (monMiniJeuChecker.DragPlace == 1)
            {
                mesDialogues = mesDialoguesB;
                nextScene = nextSceneB;
            }
        }
        #endregion
        #region BobRoss
        else if (SceneManager.GetActiveScene().name == "SceneDA")
        {
            if (monMiniJeuChecker.GyroSpace == 0)
            {
                mesDialogues = mesDialoguesA;
                nextScene = nextSceneA;
            }
            else if (monMiniJeuChecker.GyroSpace == 1)
            {
                mesDialogues = mesDialoguesB;
                nextScene = nextSceneB;
            }
        }
        #endregion
        #region Guichetier
        else if (SceneManager.GetActiveScene().name == "SceneGuichetier")
        {
            if (monMiniJeuChecker.ColorsTest == 0)
            {
                mesDialogues = mesDialoguesA;
                nextScene = nextSceneA;
            }
            else if (monMiniJeuChecker.ColorsTest == 1)
            {
                mesDialogues = mesDialoguesB;
                nextScene = nextSceneB;
            }
        }
        #endregion
        #region Guichetier
        else if (SceneManager.GetActiveScene().name == "SceneBarman")
        {
            if (monMiniJeuChecker.ShakeBranlette == 0)
            {
                mesDialogues = mesDialoguesA;
                nextScene = nextSceneA;
            }
            else if (monMiniJeuChecker.ShakeBranlette == 1)
            {
                mesDialogues = mesDialoguesB;
                nextScene = nextSceneB;
            }
        }
        #endregion
        else
        {
            mesDialogues = mesDialoguesA;
            nextScene = nextSceneA;
        }
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
            if (numeroDialogue == mesDialogues.Count - 1)
            {
                SceneManager.LoadScene(nextScene);
            }
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
