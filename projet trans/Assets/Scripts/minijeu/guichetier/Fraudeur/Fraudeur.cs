using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraudeur : MonoBehaviour
{
    public bool isFraudeur = false;
    public GameObject refBulle;
    public float vitesse;

    public SpriteRenderer sr;

    public List<Sprite> listBadge;

    public GameObject bulleBadge;
    public SpriteRenderer srBulleBadge;

    public Transform parent;

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
                srBulleBadge.sprite = listBadge[0];
                refBulle = Instantiate(bulleBadge, new Vector3(parent.position.x + 0.25f, parent.position.y + 0.5f, parent.position.z), Quaternion.identity, parent);
            }
            else
            {
                srBulleBadge.sprite = listBadge[Random.Range(1, 4)];
                refBulle = Instantiate(bulleBadge, new Vector3(parent.position.x + 0.25f, parent.position.y + 0.5f, parent.position.z), Quaternion.identity, parent);
            }
            timerMax = 99999999999999999999f;
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
                    refBulle.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }
}
