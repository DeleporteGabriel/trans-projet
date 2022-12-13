using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakerLeFaux : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;

    public float force;
    public Rigidbody rgbd;
    public float shakingMax;

    public float shakeNumber;
    public float shakeVictoire;

    public int positionLigne;

    public bool isTouch = false;

    public GameObject monPrefab;
    public List<int> quantiteColonne;

    public int colonneProche;
    public List<GameObject> mesColonnes;

    public float tempProche;

    public GameObject ocmoi;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Input.gyro.enabled = true;

        // rgbd.velocity = Vector3.up * Input.gyro.userAcceleration.magnitude*Mathf.Sign(Input.gyro.userAcceleration.z);
        /*t += Input.gyro.userAcceleration.magnitude * force;
        transform.position = Vector3.Lerp(down.position, up.position, (Mathf.Sin(t) + 1) / 2);

        if (Mathf.Sin(t) == 0 || Mathf.Sin(t) == 1)
        {
            shakeNumber++;
        }

        if (shakeNumber == shakeVictoire)
        {
            Debug.Log("ON A GAGNÉ");
        }*/

        if (Input.touchCount > 0)
        {
            if (isTouch == false)
            {
                var tempPosition = Input.touches[0].position;

                var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
                if (Physics.Raycast(tempRay, out var other))
                {
                    if (other.collider.GetComponent<ZoneDetect>() != null)
                    {
                        
                        var monObjet = Instantiate(monPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

                        tempProche = 99999;
                        for (int i = 0; i <= mesColonnes.Count - 1; i++)
                        {
                            if (Mathf.Abs(transform.position.x - mesColonnes[i].transform.position.x) < tempProche)
                            {
                                colonneProche = i;
                                tempProche = Mathf.Abs(transform.position.x - mesColonnes[i].transform.position.x);
                            }
                        }

                        quantiteColonne[colonneProche] += 1;
                        monObjet.GetComponent<CaisseRanger>().positionColonne = quantiteColonne[colonneProche];
                    }
                }
            }

            isTouch = true;
        }
        else
        {
            isTouch = false;
        }

        rgbd.velocity = new Vector3 ((Input.gyro.rotationRate.z) * -force, 0, 0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.60f), -1.5f, 0);

        /*if (shakeNumber == shakeVictoire)
        {
            maJaugeValue.AugmenteJaugeValue(1f / 6f);
            maJaugeValue.ShakeBranlette = 1;
            maJaugeValue.minijeuTermines++;
            SceneManager.LoadScene("SceneMap");
        }*/
    }
}
