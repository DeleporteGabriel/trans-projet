using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauPlacement : MonoBehaviour
{
    public GameObject monObjet;
    public GameObject monPrefab;
    public GameObject monPrefab2;
    public List<GameObject> maListe;
    public List<bool> maDispo;
    private bool faitLe = true;
    // Start is called before the first frame update
    void Start()
    {
        monObjet = new GameObject();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                maListe.Add(Instantiate(monObjet, new Vector3(-1.8f + 0.6f*j, 5.2f-0.6f*i, 1), Quaternion.identity));
                maDispo.Add(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (faitLe == true)
        {
            for (int i = 0; i < maDispo.Count; i++)
            {
                if (i >= 48 || i%7 > 4)
                {
                    if (maDispo[i] == false)
                    {
                        Instantiate(monPrefab, maListe[i].transform.position, Quaternion.identity);
                    }
                }
                else
                {
                    if (maDispo[i] == false && maDispo[i + 1] == false && maDispo[i + 2] == false && maDispo[i + 7] == false && maDispo[i + 14] == false)
                    {
                        Instantiate(monPrefab2, maListe[i].transform.position, Quaternion.identity);
                        maDispo[i + 1] = true;
                        maDispo[i + 2] = true;
                        maDispo[i + 7] = true;
                        maDispo[i + 14] = true;

                    }
                    else if (maDispo[i] == false) { Instantiate(monPrefab, maListe[i].transform.position, Quaternion.identity); }
                }
            }
            faitLe = false;
        }
    }
}
