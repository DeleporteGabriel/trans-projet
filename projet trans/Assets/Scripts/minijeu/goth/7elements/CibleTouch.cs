using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleTouch : MonoBehaviour
{
    public List<Color> listColor;
    public List<float> listRotation;
    public List<GameObject> listPositions;

    public CibleCount uniteCentral;
    public int etat;
    public int bonneCouleur;
    public int etatMax;
    public SpriteRenderer sr;

    public bool isTouch = false;
    public int typeBouton;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.touchCount > 0)
        {
            isTouch = true;
        }
        etatMax = listColor.Count - 1;

        if (typeBouton == 0)
        {
            sr.color = listColor[bonneCouleur];
        }
        else
        {
            sr.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (uniteCentral.fini == false && uniteCentral.fini == false)
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
                            var tempEtat = other.collider.GetComponent<CibleTouch>();
                            other.collider.GetComponent<CibleTouch>().etat++;
                            if (tempEtat.etat > tempEtat.etatMax)
                            {
                                tempEtat.etat = 0;
                            }
                            if (tempEtat.etat == tempEtat.bonneCouleur)
                            {
                                tempEtat.uniteCentral.cibleTrouver++;
                            }
                            else if (tempEtat.etat - 1 == tempEtat.bonneCouleur)
                            {
                                tempEtat.uniteCentral.cibleTrouver--;
                            }
                            tempEtat.uniteCentral.isTouch = true;
                            tempEtat.isTouch = true;
                        }
                    }
                }
                isTouch = true;
            }
            else
            {
                isTouch = false;
            }

            if (typeBouton == 0)
            {
                sr.color = listColor[etat];
            }
            else if (typeBouton == 1)
            {
                transform.eulerAngles = new Vector3(0, 0, listRotation[etat]);
            }
            else if (typeBouton == 2)
            {
                transform.position = new Vector3(transform.position.x, listPositions[etat].transform.position.y, transform.position.z);
            }
        }


    }
}
