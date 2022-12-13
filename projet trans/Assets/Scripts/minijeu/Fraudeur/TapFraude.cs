using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapFraude : MonoBehaviour
{
    public bool activeTouch = false;

    public int fraudeCount;

    public float timerMax;
    private float timer;

    public GameObject mesFraudeurs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            Instantiate(mesFraudeurs, new Vector3(Random.Range(-1.5f, 1.7f), 7, 0), Quaternion.identity);
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
                    }
                }
            }

            activeTouch = true;
        }
        else
        {
            activeTouch = false;
        }

        if (fraudeCount >= 3)
        {
            Debug.Log("t'as perdu");
        }
    }
}
