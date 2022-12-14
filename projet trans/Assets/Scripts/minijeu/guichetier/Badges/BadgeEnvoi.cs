using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadgeEnvoi : MonoBehaviour
{
    private bool fini = false;
    private bool debut = true;
    public GameObject victor;
    public GameObject intro;

    private GameObject monIntro;

    private IndestructibleObject maJaugeValue;

    public List<Sprite> typeBadgeColor;
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
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        srModele.sprite = typeBadgeColor[listBonBadge[badgeAvancement]];
        sr.sprite = typeBadgeColor[0];

        monIntro = Instantiate(intro, new Vector3(0, 1, 0), Quaternion.identity);
        if (Input.touchCount > 0) { isTouch = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if (debut == true)
        {
            if (Input.touchCount > 0 && isTouch == false)
            {
                debut = false;
                Destroy(monIntro);
            }

            if (Input.touchCount == 0) { isTouch = false; }
            return;
        }

        if (caDegage == false)
        {
            if (Input.touchCount > 0)
            {
                var tempPosition = Input.touches[0].position;

                var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //cr�e un rayon depuis le touch 0
                if (Physics.Raycast(tempRay, out var other))
                {
                    if (other.collider.GetComponent<BadgeSelect>() != null && isTouch == false)
                    {
                        typeBadgeNumber = other.collider.GetComponent<BadgeSelect>().badgeNumber;
                        sr.sprite = typeBadgeColor[typeBadgeNumber];
                    }
                }

                if (Input.touches[0].deltaPosition.y >= 300f)
                {
                    if (Input.touches[0].position.y > 1300)
                    {
                        caDegage = true;
                        if (listBonBadge[badgeAvancement] != typeBadgeNumber)
                        {
                            nombreErreur++;
                        }
                        else 
                        {
                            badgeAvancement++;
                            nombrenvoi++;
                        }
                    }
                }
            }

        }
        else
        {
            transform.position += new Vector3(0, 0.12f, 0);
            transform.Rotate(0, 0, 5f);
            if (transform.position.y > 15f)
            {
                caDegage = false;
                transform.position = new Vector3(0, 2.7f, 0);
                transform.rotation = Quaternion.identity;
                sr.sprite = typeBadgeColor[0];
                srModele.sprite = typeBadgeColor[listBonBadge[badgeAvancement]];
            }
        }

        if (nombrenvoi == nombreEnvoiMax)
        {
            if (fini == false)
            {
                Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                fini = true;
                maJaugeValue.removeMJ(3, 0);
            }

            if (Input.touchCount > 0)
            {
                if (isTouch == false)
                {
                    maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[3] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneGuichetier");
                }
                isTouch = true;
            }
            else { isTouch = false; }
        }

        if (Input.touchCount > 0)
        {
            isTouch = true;
        }
        else
        {
            isTouch = false;
        }
    }
}
