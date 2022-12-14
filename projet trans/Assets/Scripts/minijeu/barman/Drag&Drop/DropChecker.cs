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

    private bool fini = false;

    public GameObject victor;

    public List<GameObject> listeIngredients;
    public List<GameObject> bonIngredient;
    public List<GameObject> mauvaisIngredient;

    

    private bool isTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
        for (var i = 0; i < listeIngredients.Count; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                bonIngredient.Add(listeIngredients[i]);
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
                var tempIngredient = Instantiate(mauvaisIngredient[Random.Range(1, mauvaisIngredient.Count)], new Vector3(0 + 0.5f*i, 0, 0), Quaternion.identity);
                tempIngredient.GetComponent<DraggedObject>().isGood = false;
            }
            else
            {
                var tempIngredient = Instantiate(bonIngredient[Random.Range(1, bonIngredient.Count)], new Vector3(0 + 0.5f * i, 0, 0), Quaternion.identity);
                tempIngredient.GetComponent<DraggedObject>().isGood = true;
            }
        }

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
