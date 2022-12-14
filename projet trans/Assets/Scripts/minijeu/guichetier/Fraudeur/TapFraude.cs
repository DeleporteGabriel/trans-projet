using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapFraude : MonoBehaviour
{
    public bool activeTouch = false;
    private bool fini = false;
    private bool debut = true;
    public GameObject victor;
    public GameObject intro;

    private GameObject monIntro;

    private IndestructibleObject maJaugeValue;

    public int fraudeCount;
    public int margeFraude;

    public float timerMax;
    private float timer;

    public int pnjCount;
    public int pnjMax;
    public int pnjPass;

    public GameObject mesFraudeurs;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        monIntro = Instantiate(intro, new Vector3(0, 1, 0), Quaternion.identity);
        if (Input.touchCount > 0) { activeTouch = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if (debut == true)
        {
            if (Input.touchCount > 0 && activeTouch == false)
            {
                debut = false;
                Destroy(monIntro);
            }

            if (Input.touchCount == 0) { activeTouch = false; }
            return;
        }

        timer += Time.deltaTime;
        if (timer >= timerMax && pnjCount <= pnjMax)
        {
            Instantiate(mesFraudeurs, new Vector3(Random.Range(-1.5f, 1.7f), 7, 0), Quaternion.identity);
            pnjCount++;
            timer = 0;
        }

        if (Input.touchCount > 0)
        {
            var tempPosition = Input.touches[0].position;

            var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
            if (Physics.Raycast(tempRay, out var other) && activeTouch == false)
            {
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
            }
        }

        if (fraudeCount >= 3)
        {
            Debug.Log("t'as perdu");
        }
        if (pnjCount >= pnjMax && pnjCount <= pnjPass && fraudeCount <= margeFraude)
        {
            if (fini == false)
            {
                Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                fini = true;
                maJaugeValue.removeMJ(1, 0);
            }

            if (Input.touchCount > 0)
            {
                if (activeTouch == false)
                {
                    maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[1] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneGuichetier");
                }
                activeTouch = true;
            }
            else { activeTouch = false; }
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
