using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraudeur : MonoBehaviour
{
    public bool isFraudeur = false;
    public float vitesse;

    public SpriteRenderer sr;

    public float timerMax;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            isFraudeur = true;
        }

        vitesse = Random.Range(0.0005f, 0.002f);
        timerMax = Random.Range(1.7f, 2.2f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            if (isFraudeur)
            {
                sr.color = Color.red;
            }
            else
            {
                sr.color = Color.green;
            }
        }
        transform.position += Vector3.down * vitesse;

        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out var otherB))
        {
            if (otherB.collider.GetComponent<TapFraude>() != null)
            {
                if (sr.enabled == true)
                {
                    if (isFraudeur == true)
                    {
                        otherB.collider.GetComponent<TapFraude>().fraudeCount++;
                    }
                    sr.enabled = false;
                }
            }
        }
    }
}
