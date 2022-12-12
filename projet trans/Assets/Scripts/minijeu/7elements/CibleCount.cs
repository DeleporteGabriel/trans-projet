using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CibleCount : MonoBehaviour
{
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
            //maJaugeValue.jaugeHype += 70;
            maJaugeValue.AugmenteJaugeValue(1f / 6f);
            maJaugeValue.Cibles = 1;
            maJaugeValue.minijeuTermines++;
            SceneManager.LoadScene("SceneBenevol");
        }
    }
}
