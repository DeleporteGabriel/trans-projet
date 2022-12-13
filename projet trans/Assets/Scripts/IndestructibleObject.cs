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

    public int minijeuTermines;

    public JaugeParametre jp;

    private int addMonMJ;
    private int addMonPerso;

    private IconeColors[] allIcones;
    private bool isInScene = false;
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
        if (currentMJ.Count == 0 && SceneManager.GetActiveScene().name == "SceneMap")
        {
            currentMJ.Clear();
            currentPerso.Clear();

            for (int i = 0; i < 4; i++)
            {
                var isHere = true;
                while (isHere == true)
                {
                    isHere = false;

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
                currentMJ.Add(addMonMJ);
                currentPerso.Add(addMonPerso);
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
    }
}
