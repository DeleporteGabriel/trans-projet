using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeEnvoi : MonoBehaviour
{
    public List<Color> typeBadgeColor;
    public List<int> listBonBadge;
    public int badgeAvancement;

    public int nombreErreur;

    public int nombreEnvoiMax;
    public int nombrenvoi;

    public int typeBadgeNumber;

    public SpriteRenderer sr;
    public SpriteRenderer srModele;
    private bool isTouch = false;
    private bool caDegage = false;
    // Start is called before the first frame update
    void Start()
    {
        srModele.color = typeBadgeColor[listBonBadge[badgeAvancement]];
    }

    // Update is called once per frame
    void Update()
    {
        if (caDegage == false)
        {
            if (Input.touchCount > 0)
            {
                var tempPosition = Input.touches[0].position;

                var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
                if (Physics.Raycast(tempRay, out var other))
                {
                    if (other.collider.GetComponent<BadgeSelect>() != null && isTouch == false)
                    {
                        typeBadgeNumber = other.collider.GetComponent<BadgeSelect>().badgeNumber;
                        sr.color = typeBadgeColor[typeBadgeNumber];
                    }
                }

                if (Input.touches[0].deltaPosition.y >= 300f)
                {
                    if (Input.touches[0].position.y > 1300)
                    {
                        caDegage = true;
                        badgeAvancement++;
                        if (listBonBadge[badgeAvancement] != typeBadgeNumber)
                        {
                            nombreErreur++;
                        }
                    }
                }
                isTouch = true;
            }
            else
            {
                isTouch = false;
            }
        }
        else
        {
            transform.position += new Vector3(0, 0.09f, 0);
            if (transform.position.y > 15f)
            {
                caDegage = false;
                transform.position = new Vector3(0, 1.5f, 0);
                sr.color = typeBadgeColor[0];
                srModele.color = typeBadgeColor[listBonBadge[badgeAvancement]];
            }
        }
    }
}
