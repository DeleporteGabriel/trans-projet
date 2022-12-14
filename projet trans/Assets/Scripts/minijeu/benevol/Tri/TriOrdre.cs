using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriOrdre : MonoBehaviour
{
    private bool isTouch = false;
    private bool fini = false;
    private bool debut = true;
    public GameObject victor;
    public GameObject intro;

    private GameObject monIntro;

    private IndestructibleObject maJaugeValue;

    public List<int> ordreCorrect;
    public List<TriBloc> listBlocs;

    public int winCounter;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        for (int i = 0; i < ordreCorrect.Count; i++)
        {
            int temp = ordreCorrect[i];
            int randomIndex = Random.Range(i, ordreCorrect.Count);
            ordreCorrect[i] = ordreCorrect[randomIndex];
            ordreCorrect[randomIndex] = temp;
        }

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
            }

            if (Input.touchCount == 0) { isTouch = false; }
            return;
        }

        winCounter = 0;
        for (var i = 0; i < ordreCorrect.Count; i++)
        {
            if (ordreCorrect[i] == listBlocs[i].placeBloc)
            {
                winCounter++;
            }
        }
        if (winCounter >= ordreCorrect.Count)
        {
            if (fini == false)
            {
                Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                fini = true;
                maJaugeValue.removeMJ(4, 2);
            }

            if (Input.touchCount > 0)
            {
                if (isTouch == false)
                {
                    maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[4] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneBenevol");
                }
                isTouch = true;
            }
            else { isTouch = false; }
        }
    }
}
