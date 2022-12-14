using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropChecker : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;

    public int totalDrop;
    public int currentDrop;
    public int isCorrect;

    public int diffucltLevel = 1;//niveau de difficulter 1-3 ********INFLUENCE LES TROIS VALEUR SUIVANTE********
        public int numberGood = 1;//nombre de bon ingredient
        public int totalNumber = 1;//nombre total d'ingredients
        public int errortCount = 1;//nombre d'erreur avant echec

    private bool fini = false;

    public GameObject victor;

    public SpriteRenderer SkinVerre;

    public List<GameObject> listeIngredients;
    public List<GameObject> bonIngredient;
    public List<GameObject> mauvaisIngredient;
    public List<Sprite> listSkinVerre;

    private bool isTouch = false;
    // Start is called before the first frame update
    void Start()
    {

        if (diffucltLevel==1)
        {
            numberGood = 3;
            totalNumber = 6;
            errortCount = 3;
        }
        if (diffucltLevel == 2)
        {
            numberGood = 4;
            totalNumber = 8;
            errortCount = 2;
        }
        if (diffucltLevel == 3)
        {
            numberGood = 6;
            totalNumber = 12;
            errortCount = 1;
        }

        maJaugeValue = FindObjectOfType<IndestructibleObject>();
        for (var i = 0; i < totalNumber; i++)
        {
            if (Random.Range(0, 2) == 0 && numberGood >= 0)
            {
                bonIngredient.Add(listeIngredients[i]) ;
                numberGood-- ;
            }
            else
            {
                mauvaisIngredient.Add(listeIngredients[i]);
            }
        }

        for (int i = 0; i < 6; i++)
        {
            var tempRand = Random.Range(0, 2);

            if (tempRand == 0)
            {
                var tempIngredient = Instantiate(mauvaisIngredient[Random.Range(1, mauvaisIngredient.Count)], new Vector3(-1 + 0.5f*i, 4, 0), Quaternion.identity);
                tempIngredient.GetComponent<DraggedObject>().isGood = false;
            }
            else
            {
                var tempIngredient = Instantiate(bonIngredient[Random.Range(1, bonIngredient.Count)], new Vector3(-1 + 0.5f * i, 2 , 0), Quaternion.identity);
                tempIngredient.GetComponent<DraggedObject>().isGood = true;
                totalDrop++;
            }
        }

        SkinVerre.sprite = listSkinVerre[Random.Range(0, listSkinVerre.Count)];

    }

    // Update is called once per frame
    void Update()
    {
        if (totalDrop == currentDrop && isCorrect == 0)
        {
            //maJaugeValue.jaugeHype += 70;
            /*maJaugeValue.AugmenteJaugeValue(1f / 6f);
            maJaugeValue.DragDrop = 1;
            maJaugeValue.minijeuTermines++;
            SceneManager.LoadScene("SceneLightGirl");*/
            if (fini == false)
            {
                Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                fini = true;
                maJaugeValue.removeMJ(11, 3);
            }

            if (Input.touchCount > 0)
            {
                if (isTouch == false)
                {
                    maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[11] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneBarman");
                }
                isTouch = true;
            }
            else { isTouch = false; }
        }
    }
}
