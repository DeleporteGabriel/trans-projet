using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DropChecker : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;

    public List<Sprite> verreVide;
    public List<Sprite> verreRempli;

    private int numeroVerre;

    public int totalDrop;
    public int currentDrop;
    public int isCorrect;

    public int etapeFini;
    public int etapeMax;

    public int diffucltLevel = 1;//niveau de difficulter 1-3 ********INFLUENCE LES TROIS VALEUR SUIVANTE********
    public int numberGood = 1;//nombre de bon ingredient
    public int totalNumber = 1;//nombre total d'ingredients
    public int errorMax = 1;//nombre d'erreur avant echec
    public int currentError;

    private bool fini = false;
    private bool debut = true;

    private string textAffiche;

    public TextMeshProUGUI monTexte;

    public VictoireDefaite maFin;

    public SpriteRenderer skinVerre;

    public List<GameObject> listeIngredients;
    public List<GameObject> bonIngredient;
    public List<GameObject> mauvaisIngredient;
    public List<string> feur;
    public List<string> feurBon;
    public List<string> feurMauvais;


    private bool isTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        numeroVerre = Random.Range(0, 3);
        skinVerre.sprite = verreVide[numeroVerre];

        if (diffucltLevel==1)
        {
            numberGood = 2;
            totalDrop = numberGood;
            totalNumber = 4;
            errorMax = 2;
            etapeMax = 3;
        }
        if (diffucltLevel == 2)
        {
            numberGood = 4;
            totalDrop = numberGood;
            totalNumber = 6;
            errorMax = 1;
            etapeMax = 3;
        }
        if (diffucltLevel == 3)
        {
            numberGood = 6;
            totalDrop = numberGood;
            totalNumber = 8;
            errorMax = 0;
            etapeMax = 4;
        }

        maJaugeValue = FindObjectOfType<IndestructibleObject>();
        for (var i = 0; i < listeIngredients.Count; i++)
        {
            if (Random.Range(0, 2) == 0 && numberGood >= 0)
            {
                bonIngredient.Add(listeIngredients[i]) ;
                feurBon.Add(feur[i]);
            }
            else
            {
                mauvaisIngredient.Add(listeIngredients[i]);
                feurMauvais.Add(feur[i]);
            }
        }

        for (int i = 0; i < totalNumber; i++)
        {

            if (numberGood > 0)
            {
                var tempRand = Random.Range(1, bonIngredient.Count);
                var tempIngredient = Instantiate(bonIngredient[tempRand], new Vector3(Random.Range(-1f, 1f), Random.Range(2f, 5f), 0), Quaternion.identity);
                tempIngredient.GetComponent<DraggedObject>().isGood = true;
                tempIngredient.GetComponent<DraggedObject>().uniteCentrale = gameObject.GetComponent<DropChecker>();
                textAffiche += feurBon[tempRand-1];
                textAffiche += "\n";
                numberGood--;
            }
            else
            {
                var tempIngredient = Instantiate(mauvaisIngredient[Random.Range(1, mauvaisIngredient.Count)], new Vector3(Random.Range(-1f, 1f), Random.Range(2f, 5f), 0), Quaternion.identity);
                tempIngredient.GetComponent<DraggedObject>().isGood = false;
                tempIngredient.GetComponent<DraggedObject>().uniteCentrale = gameObject.GetComponent<DropChecker>();
            }
        }
        monTexte.text = textAffiche;
        if (Input.touchCount > 0) { isTouch = true; }

    }

    // Update is called once per frame
    void Update()
    {
        if (maFin.debut == true)
        { 
            return;
        }

        //reset étape
        if (totalDrop == currentDrop)
        {
            etapeFini++;
            if (isCorrect != 0)
            {
                currentError++;
            }

            skinVerre.sprite = verreRempli[numeroVerre];

            currentDrop = 0;
            numberGood = totalDrop;
            isCorrect = 0;
            textAffiche = "";

            Invoke("ResetRound", 2);            
        }

        if (etapeFini == etapeMax &&  currentError <= errorMax)
        {
            skinVerre.sprite = verreRempli[numeroVerre];
            maFin.Victoire(11, 3);

            if (Input.touchCount > 0)
            {
                isTouch = true;
            }
            else { isTouch = false; }
        }

        if (currentError > errorMax)
        {
            maFin.Defaite(11, 3);
        }
    }

    public void ResetRound()
    {
        bonIngredient.Clear();
        bonIngredient.Add(listeIngredients[0]);
        feurBon.Clear();
        mauvaisIngredient.Clear();
        mauvaisIngredient.Add(listeIngredients[0]);
        feurMauvais.Clear();

        numeroVerre = Random.Range(0, verreVide.Count);
        skinVerre.sprite = verreVide[numeroVerre];

        if (etapeFini < etapeMax)
        {
            for (var i = 0; i < listeIngredients.Count; i++)
            {
                if (Random.Range(0, 2) == 0 && numberGood >= 0)
                {
                    bonIngredient.Add(listeIngredients[i]);
                    feurBon.Add(feur[i]);
                }
                else
                {
                    mauvaisIngredient.Add(listeIngredients[i]);
                    feurMauvais.Add(feur[i]);
                }
            }

            for (int i = 0; i < totalNumber; i++)
            {

                if (numberGood > 0)
                {
                    var tempRand = Random.Range(1, bonIngredient.Count);
                    var tempIngredient = Instantiate(bonIngredient[tempRand], new Vector3(Random.Range(-1f, 1f), Random.Range(2f, 5f), 0), Quaternion.identity);
                    tempIngredient.GetComponent<DraggedObject>().isGood = true;
                    tempIngredient.GetComponent<DraggedObject>().uniteCentrale = gameObject.GetComponent<DropChecker>();
                    textAffiche += feurBon[tempRand - 1];
                    textAffiche += "\n";
                    numberGood--;
                }
                else
                {
                    var tempIngredient = Instantiate(mauvaisIngredient[Random.Range(1, mauvaisIngredient.Count)], new Vector3(Random.Range(-1f, 1f), Random.Range(2f, 5f), 0), Quaternion.identity);
                    tempIngredient.GetComponent<DraggedObject>().isGood = false;
                    tempIngredient.GetComponent<DraggedObject>().uniteCentrale = gameObject.GetComponent<DropChecker>();
                }
            }
            monTexte.text = textAffiche;
        }
    }
}
