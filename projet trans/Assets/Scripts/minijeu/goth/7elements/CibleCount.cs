using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CibleCount : MonoBehaviour
{
    public bool isTouch = false;
    private bool fini = false;
    private bool debut = true;
    public GameObject victor;
    public GameObject intro;

    private GameObject monIntro;

    private IndestructibleObject maJaugeValue;

    public int totalCible;
    public int cibleTrouver;

    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
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

        if (totalCible == cibleTrouver)
        {
            if (fini == false)
            {
                Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                fini = true;
                maJaugeValue.removeMJ(15, 4);
            }

            if (Input.touchCount > 0)
            {
                if (isTouch == false)
                {
                    maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[15] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneGoth");
                }
                isTouch = true;
            }
            else { isTouch = false; }
        }
    }
}
