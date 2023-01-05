using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpecifique : MonoBehaviour
{
    public int correspondance;
    public TableauPlacement monTableau;
    public int colonne;
    public int ligne;

    private bool canPlace = false;
    // Start is called before the first frame update
    void Start()
    {
        //check placement

        while (canPlace == false)
        {
            canPlace = true;
            ligne = Random.Range(0, 8);
            colonne = Random.Range(0, 5);
            //coin
            if (correspondance == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (monTableau.maDispo[colonne + i + (7 * (ligne + j))] == true) { canPlace = false; }
                    }
                }
                if (monTableau.maDispo[colonne + (7 * (ligne + 2))] == true) { canPlace = false; }
                if (monTableau.maDispo[colonne + 1 + (7 * (ligne + 2))] == true) { canPlace = false; }
                }
                //long
                if (correspondance == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (monTableau.maDispo[colonne + i + (7 * (ligne + j))] == true) { canPlace = false; }
                        }
                    }
                }
                //carré
                if (correspondance == 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (monTableau.maDispo[colonne + i + (7 * (ligne + j))] == true) { canPlace = false; }
                        }
                    }
                }
            }

        transform.position = monTableau.maListe[colonne + (7*ligne)].transform.position;

        //coin
        if (correspondance == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    monTableau.maDispo[colonne + i + (7 * (ligne + j))] = true;
                }
            }
            monTableau.maDispo[colonne + (7 * (ligne + 2))] = true;
            monTableau.maDispo[colonne + 1 + (7 * (ligne+2))] = true;
        }
        //long
        if (correspondance == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    monTableau.maDispo[colonne + i + (7 * (ligne + j))] = true;
                }
            }
        }
        //carré
        if (correspondance == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    monTableau.maDispo[colonne + i + (7 * (ligne + j))] = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
