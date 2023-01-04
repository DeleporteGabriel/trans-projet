using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpecifique : MonoBehaviour
{
    public int correspondance;
    public TableauPlacement monTableau;
    private int colonne;
    private int ligne;
    // Start is called before the first frame update
    void Start()
    {
        ligne = Random.Range(0, 6);
        colonne = Random.Range(0, 5);

        transform.position = monTableau.maListe[colonne + 7*ligne].transform.position;

        /*if (correspondance == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    monTableau.maDispo[colonne + i + (7 + i) * ligne] = true;
                }
            }
        }*/
        if (correspondance == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    monTableau.maDispo[colonne + i + (7 + j) * ligne] = true;
                }
            }
        }
        /*if (correspondance == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    monTableau.maDispo[colonne + i + (7 + i) * ligne] = true;
                }
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
