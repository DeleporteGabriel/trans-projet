using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauPlacement : MonoBehaviour
{
    public GameObject monObjet;
    public GameObject monPrefab;
    public List<GameObject> maListe;
    public List<bool> maDispo;
    // Start is called before the first frame update
    void Start()
    {
        monObjet = new GameObject();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                maListe.Add(Instantiate(monObjet, new Vector3(-1.8f + 0.6f*i, 5.2f-0.6f*j, 1), Quaternion.identity));
                maListe.Add(Instantiate(monPrefab, new Vector3(-1.8f + 0.6f * i, 5.2f - 0.6f * j, 1), Quaternion.identity));
                maDispo.Add(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
