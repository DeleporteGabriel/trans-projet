using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CibleCount : MonoBehaviour
{
    public bool isTouch = false;
    private bool fini = false;
    public GameObject victor;

    private IndestructibleObject maJaugeValue;

    public int totalCible;
    public int cibleTrouver;

    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
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
