using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleTouch : MonoBehaviour
{
    public List<Color> listColor;

    public CibleCount uniteCentral;
    public int etat;
    public int bonneCouleur;
    public int etatMax;
    public SpriteRenderer sr;

    public bool isTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.touchCount > 0)
        {
            isTouch = true;
        }
        etatMax = listColor.Count - 1;

        sr.color = listColor[bonneCouleur];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var tempPosition = Input.touches[0].position;

            var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
            if (Physics.Raycast(tempRay, out var other))
            {
                if (other.collider.GetComponent<CibleTouch>() != null)
                {
                    if (other.collider.GetComponent<CibleTouch>().isTouch == false)
                    {
                        var tempEtat = other.collider.GetComponent<CibleTouch>().etat;
                        other.collider.GetComponent<CibleTouch>().etat++;
                        if (other.collider.GetComponent<CibleTouch>().etat > other.collider.GetComponent<CibleTouch>().etatMax)
                        {
                            other.collider.GetComponent<CibleTouch>().etat = 0;
                        }
                        if (other.collider.GetComponent<CibleTouch>().etat == other.collider.GetComponent<CibleTouch>().bonneCouleur)
                        {
                            other.collider.GetComponent<CibleTouch>().uniteCentral.cibleTrouver++;
                        }
                        else if (tempEtat == other.collider.GetComponent<CibleTouch>().bonneCouleur)
                        {
                            other.collider.GetComponent<CibleTouch>().uniteCentral.cibleTrouver--;
                        }
                        other.collider.GetComponent<CibleTouch>().uniteCentral.isTouch = true;
                        other.collider.GetComponent<CibleTouch>().isTouch = true;
                    }
                }
            }
            isTouch = true;
        }
        else 
        { 
            isTouch = false;
        }

        sr.color = listColor[etat];


    }
}
