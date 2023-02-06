using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakerLeFaux : MonoBehaviour
{
    [SerializeField]
    private VictoireDefaite maFin;

    private IndestructibleObject maJaugeValue;

    public float force;
    public Rigidbody rgbd;

    public int currentScore;
    public int scoreMax;
    public int currentError;
    public int errorRange;

    public int positionLigne;

    public bool isTouch = false;

    public GameObject monPrefab;
    public List<int> quantiteColonne;

    public int colonneProche;
    public List<GameObject> mesColonnes;

    public float tempProche;

    public GameObject ocmoi;

    public GameObject monObjet;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        if (Input.touchCount > 0) { isTouch = true; }

        monObjet = Instantiate(monPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
        monObjet.GetComponent<CaisseRanger>().monElevateur = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (maFin.debut == true || maFin.fini == true)
        {
            return;
        }

        Input.gyro.enabled = true;

        if (Input.touchCount > 0)
        {
            if (isTouch == false)
            {
                tempProche = 99999;
                for (int i = 0; i <= mesColonnes.Count - 1; i++)
                {
                    if (Mathf.Abs(transform.position.x - mesColonnes[i].transform.position.x) < tempProche)
                    {
                        colonneProche = i;
                        tempProche = Mathf.Abs(transform.position.x - mesColonnes[i].transform.position.x);
                    }
                }

                if (quantiteColonne[colonneProche] <= 4)
                {
                    quantiteColonne[colonneProche] += 1;
                    monObjet.GetComponent<CaisseRanger>().positionColonne = quantiteColonne[colonneProche];
                    monObjet.GetComponent<CaisseRanger>().colonneProche = colonneProche;
                    monObjet.GetComponent<CaisseRanger>().isShoot = true;
                    monObjet.GetComponent<CaisseRanger>().transform.position = new Vector3(mesColonnes[colonneProche].transform.position.x, transform.position.y, -1);

                    monObjet = Instantiate(monPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                    monObjet.GetComponent<CaisseRanger>().monElevateur = gameObject;
                }
            }
        }

        rgbd.velocity = new Vector3 ((Input.gyro.rotationRate.z) * -force, 0, 0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.60f), -0.5f, 0);

        if (currentScore >= scoreMax && currentError <= errorRange)
        {
            maFin.Victoire(5, 1);

            if (Input.touchCount > 0)
            {
                if (isTouch == false)
                {
                    maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[5] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneBenevol");
                }
            }
        }
        if (currentError > errorRange)
        {
            maFin.Defaite(5, 1);
        }

        if (Input.touchCount > 0)
        {
            isTouch = true;
        }
        else
        {
            isTouch = false;
        }

        /*if (shakeNumber == shakeVictoire)
        {
            maJaugeValue.AugmenteJaugeValue(1f / 6f);
            maJaugeValue.ShakeBranlette = 1;
            maJaugeValue.minijeuTermines++;
            SceneManager.LoadScene("SceneMap");
        }*/
    }
}
