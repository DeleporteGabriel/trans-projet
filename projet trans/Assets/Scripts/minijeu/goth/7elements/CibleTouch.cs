using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleTouch : MonoBehaviour
{

    public CibleCount uniteCentral;
    public bool trouver = false;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    if (other.collider.GetComponent<CibleTouch>().trouver == false)
                    {
                        other.collider.GetComponent<CibleTouch>().trouver = true;
                        other.collider.GetComponent<CibleTouch>().sr.color = Color.cyan;
                        other.collider.GetComponent<CibleTouch>().uniteCentral.cibleTrouver++;
                        uniteCentral.isTouch = true;
                    }
                }
            }
        }
    }
}
