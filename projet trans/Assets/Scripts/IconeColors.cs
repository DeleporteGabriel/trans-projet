using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconeColors : MonoBehaviour
{
    public int monPerso;
    private IndestructibleObject maJaugeValue;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void afficheBon()
    {
        sr.enabled = false;

        for (int i = 0; i <= maJaugeValue.currentPerso.Count - 1; i++)
        {
            if (maJaugeValue.currentPerso[i] == monPerso)
            {
                sr.enabled = true;
            }
        }

        if (sr.enabled == false)
        {
            Destroy(gameObject);
        }
    }
}
