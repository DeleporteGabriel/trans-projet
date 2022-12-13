using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaisseRanger : MonoBehaviour
{
    public List<GameObject> mesColonnes;
    public GameObject monElevateur;

    public int colonneProche;
    public float tempProche;
    private bool stopBloc = false;

    public List<int> quantiteColonne;

    public int positionColonne;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= mesColonnes.Count - 1; i++)
        {
            if (Mathf.Abs(transform.position.x - mesColonnes[i].transform.position.x) < tempProche)
            {
                colonneProche = i;
                tempProche = Mathf.Abs(transform.position.x - mesColonnes[i].transform.position.x);
            }
        }

        transform.position = new Vector3(mesColonnes[colonneProche].transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 5 && stopBloc == false)
        {
            transform.position += new Vector3(0, 0.05f, 0);
        }
        else
        {
            if (stopBloc == false)
            {
                transform.position = new Vector3(transform.position.x, 5.75f - (positionColonne * 1.25f), 0);
                stopBloc = true;
            }
        }
    }
}
