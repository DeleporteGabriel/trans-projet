using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapFraude : MonoBehaviour
{
    public bool activeTouch = false;

    [SerializeField]
    private VictoireDefaite maFin;

    private IndestructibleObject maJaugeValue;

    public int fraudeCount;
    public int margeFraude;

    public float timerMax;
    private float timer;

    public int pnjCount;
    public int pnjMax;
    public int pnjPass;

    public GameObject mesFraudeurs;

    private int diffulctLevel;
    private float vitesseFraude;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
        diffulctLevel = maJaugeValue.difficulty;

        if (diffulctLevel == 1)
        {
            margeFraude = 3;
            vitesseFraude = 1;

        }
        else if (diffulctLevel == 2)
        {
            margeFraude = 2;
            vitesseFraude = 1.2f;
        }
        else if (diffulctLevel == 3)
        {
            margeFraude = 0;
            vitesseFraude = 1.5f;
        }

        if (Input.touchCount > 0) { activeTouch = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if (maFin.debut == true || maFin.fini == true)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= timerMax && pnjCount <= pnjMax)
        {
            var monFraude = Instantiate(mesFraudeurs, new Vector3(Random.Range(-1.5f, 1.7f), 7, 0), Quaternion.identity);
            monFraude.GetComponent<Fraudeur>().vitesse *= vitesseFraude;
            pnjCount++;
            timer = 0;
        }

        if (Input.touchCount > 0)
        {
            var tempPosition = Input.touches[0].position;

            var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
            if (Physics.Raycast(tempRay, out var other) && activeTouch == false)
            {
                //detecte le fraudeur
                if (other.collider.GetComponent<Fraudeur>() != null)
                {
                    var targetObject = other.collider.GetComponent<Fraudeur>();

                    if (targetObject.isFraudeur == true)
                    {
                        targetObject.sr.enabled = false;
                        targetObject.refBulle.GetComponent<SpriteRenderer>().enabled =false ;
                        pnjPass++;
                    }
                    else
                    {
                        fraudeCount++;
                    }
                }
                //detecte sa bulle
                if (other.collider.GetComponent<BulleFraude>() != null)
                {
                    var targetObject = other.collider.GetComponent<BulleFraude>().monFraudeur;

                    if (targetObject.isFraudeur == true)
                    {
                        targetObject.sr.enabled = false;
                        targetObject.refBulle.GetComponent<SpriteRenderer>().enabled = false;
                        pnjPass++;
                    }
                    else
                    {
                        fraudeCount++;
                    }
                }
            }
        }

        if (fraudeCount >= 3)
        {
            maFin.Defaite(1, 0);
        }
        if (pnjCount >= pnjMax && pnjCount <= pnjPass && fraudeCount <= margeFraude)
        {
            maFin.Victoire(1, 0);
        }

        if (Input.touchCount > 0)
        {
            activeTouch = true;
        }
        else
        {
            activeTouch = false;
        }
    }
}
