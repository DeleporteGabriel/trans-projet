using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimonManager : MonoBehaviour
{
    [SerializeField]
    private VictoireDefaite maFin;

    private IndestructibleObject maJaugeValue;

    public List<SpriteRenderer> mesModeles;
    public List<SpriteRenderer> mesSimons;

    public List<Color> colorModele;

    public List<int> mesReponses;
    public List<int> maSerie;

    public int monAvancement;
    public int isRight;

    private bool isTouch = false;

    private bool simonIsPlaying = false;

    public float timer;
    public float timerMax;
    public int iModele;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        simonIsPlaying = true;

        if (Input.touchCount > 0) { isTouch = true; }

    }

    // Update is called once per frame
    void Update()
    {
        if (maFin.debut == true || maFin.fini == true)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= timerMax / 2 && iModele != 0)
        {
            mesModeles[mesReponses[iModele-1]].color = new Vector4(1, 1, 1, 0.5f);
        }
        if (simonIsPlaying)
        {
            if (timer >= timerMax)
            {
                iModele++;
                mesModeles[mesReponses[iModele-1]].color = colorModele[mesReponses[iModele-1]];
                timer = 0;
            }
            if (iModele >= mesReponses.Count)
            {
                simonIsPlaying = false;
            }
        }

        if (Input.touchCount > 0)
        {
            if (isTouch == false)
            {
                if (simonIsPlaying == false)
                {
                    var tempPosition = Input.touches[0].position;

                    var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
                    if (Physics.Raycast(tempRay, out var other))
                    {
                        if (other.collider.GetComponent<IsSimon>() != null)
                        {
                            //action
                            var autreSimon = other.collider.GetComponent<IsSimon>();
                            mesSimons[autreSimon.quelSimon].color = Color.white;
                            maSerie.Add(autreSimon.quelSimon);
                            autreSimon.isWhite = true;
                            isTouch = true;
                        }
                    }
                }
            }
            if (maSerie.Count != 0)
            {
                for (int i = 0; i <= maSerie.Count - 1 && i <= mesReponses.Count - 1; i++)
                {
                    if (mesReponses[i] == maSerie[i])
                    {
                        isRight++;
                    }
                }
                if (isRight == mesReponses.Count)
                {
                    maFin.Victoire(18, 5);
                }
                else if (maSerie.Count >= mesReponses.Count)
                {
                    maFin.Defaite(18, 5);
                }
            }
            isTouch = true;
        }


        isRight = 0;
        if (Input.touchCount == 0)
        {
            isTouch = false;
        }
    }
}
