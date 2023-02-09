using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndestructibleObject : MonoBehaviour
{
    [Range(0.1f,100f)]
    public float jaugeHypeMax;
    private float currentJaugeHype = 0;

    public List<int> faitOuPasFait;

    //Liste minijeux
    public List<string> mesMinijeux;

    public List<int> guichMJ;
    public List<int> beneMJ;
    public List<int> daMJ;
    public List<int> barMJ;
    public List<int> sonoMJ;
    public List<int> lightMJ;

    public List<List<int>> mesPersos = new List<List<int>>();
    public List<int> currentMJ;
    public List<int> currentPerso;
    public List<int> futurPersos;

    public int minijeuTermines;
    public int minijeuGagne;

    public JaugeParametre jp;

    private int addMonMJ;
    private int addMonPerso;

    private IconeColors[] allIcones;
    private bool isInScene = false;

    public int LastPlayedMinigame;
    public bool isMinigameWin;

    //temps de jeu
    public float tempsDeJeu_ = 0;
    private bool lanceTimer = false;
    //difficulté
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        mesPersos.Add(guichMJ);
        mesPersos.Add(beneMJ);
        mesPersos.Add(daMJ);
        mesPersos.Add(barMJ);
        mesPersos.Add(sonoMJ);
        mesPersos.Add(lightMJ);

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (lanceTimer == true)
        {
            tempsDeJeu_ += Time.deltaTime;
        }

        if (currentMJ.Count == 0 && SceneManager.GetActiveScene().name == "SceneMap" && minijeuTermines < 12)
        {
            currentMJ.Clear();
            currentPerso.Clear();

            for (int i = 0; currentMJ.Count < 4; i++)
            {
                var isHere = true;
                while (isHere == true || addMonMJ == 2 || addMonMJ == 6 || addMonMJ == 7 || addMonMJ == 12 || addMonMJ == 14 || addMonMJ == 17 || faitOuPasFait[addMonMJ] == 1)
                {
                    isHere = false;

                    if (minijeuTermines == 4 && currentMJ.Count < 2)
                    {

                        var pasPossible = true;
                        while (pasPossible == true || addMonMJ == 2 || addMonMJ == 6 || addMonMJ == 7 || addMonMJ == 12 || addMonMJ == 14 || addMonMJ == 17)
                        {
                            addMonMJ = mesPersos[futurPersos[i]][Random.Range(0, 3)];
                            pasPossible = false;
                        }

                        addMonPerso = futurPersos[i];
                    }
                    else
                    {
                        var tempPerso = Random.Range(0, 6);
                        var tempMJ = Random.Range(0, 3);

                        addMonMJ = mesPersos[tempPerso][tempMJ];
                        addMonPerso = tempPerso;

                        for (int j = 0; j <= currentMJ.Count - 1; j++)
                        {
                            if (currentPerso[j] == addMonPerso)
                            {
                                isHere = true;
                            }
                        }
                    }
                }
                currentMJ.Add(addMonMJ);
                currentPerso.Add(addMonPerso);
            }
            if (minijeuTermines == 0)
            {
                futurPersos.Add(0); futurPersos.Add(1); futurPersos.Add(2); futurPersos.Add(3); futurPersos.Add(4); futurPersos.Add(5);
                for (int k = 0; k < 4; k++)
                {
                    for (int l = 0; l < futurPersos.Count; l++)
                    {
                        if (currentPerso[k] == futurPersos[l])
                        {
                            futurPersos.Remove(futurPersos[l]);
                        }
                    }
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "SceneMap" && isInScene == false)
        {
            allIcones = FindObjectsOfType<IconeColors>();
            foreach (var item in allIcones)
            {
                item.afficheBon();
            }
            isInScene = true;
        }
        if (SceneManager.GetActiveScene().name != "SceneMap")
        {
            isInScene = false;
        }


        if (SceneManager.GetActiveScene().name == "FirstScene" && (Input.touchCount > 0))
        {
            lanceTimer = true;
            SceneManager.LoadScene("SceneIntro");
        }
    }

    public float GetJaugeRatio() => currentJaugeHype / jaugeHypeMax;


    public void ChangeJaugeHype()
    {
        if(jp == null)
        {
            jp = FindObjectOfType<JaugeParametre>();
        }
        currentJaugeHype = Mathf.Clamp(currentJaugeHype, 0, jaugeHypeMax);
        jp.UpdateJauge(GetJaugeRatio());
    }

    public void AugmenteJaugeValue(float addValue)
    {
        currentJaugeHype += addValue;
    }

    public void removeMJ(int monMinijeuRemove, int monPersoRemove)
    {
        currentMJ.Remove(monMinijeuRemove);
        currentPerso.Remove(monPersoRemove);
        LastPlayedMinigame = monMinijeuRemove;
    }
}
