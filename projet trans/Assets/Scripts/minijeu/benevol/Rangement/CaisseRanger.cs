using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaisseRanger : MonoBehaviour
{
    public int caisseType;
    public List<Sprite> mesCaisses;

    public List<GameObject> mesColonnes;
    public GameObject monElevateur;
    public SpriteRenderer sr;

    public int colonneProche;
    public float tempProche;
    public float vitesseCaisse;
    private bool stopBloc = false;

    public List<int> quantiteColonne;

    public int positionColonne;

    public bool isShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        caisseType = Random.Range(0, 4);
        sr.sprite = mesCaisses[caisseType];

        for (int i = 0; i <= mesColonnes.Count - 1; i++)
        {
            if (Mathf.Abs(transform.position.x - mesColonnes[i].transform.position.x) < tempProche)
            {
                colonneProche = i;
                tempProche = Mathf.Abs(transform.position.x - mesColonnes[i].transform.position.x);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isShoot == false)
        {
            transform.position = new Vector3(monElevateur.transform.position.x, monElevateur.transform.position.y + 0.5f, -1);
        }
        else
        {
            if (transform.position.y < 5.75f - (positionColonne * 1f) && stopBloc == false)
            {
                transform.position += new Vector3(0, vitesseCaisse * Time.deltaTime, 0);
            }
            else
            {
                if (stopBloc == false)
                {
                    transform.position = new Vector3(transform.position.x, 5.75f - (positionColonne * 1f), -1);
                    if (colonneProche == caisseType)
                    {
                        monElevateur.GetComponent<ShakerLeFaux>().currentScore++;
                    }
                    else 
                    { 
                        monElevateur.GetComponent<ShakerLeFaux>().currentError++;
                    }
                    stopBloc = true;
                }
            }
        }
    }
}
