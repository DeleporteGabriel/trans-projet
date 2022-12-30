using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimonManager : MonoBehaviour
{
    private bool fini = false;
    private bool debut = true;
    public GameObject victor;
    public GameObject defat;
    public GameObject intro;

    private GameObject monIntro;

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
                    if (fini == false)
                    {
                        Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                        fini = true;

                        maJaugeValue.removeMJ(18, 5);
                    }

                    if (Input.touchCount > 0)
                    {
                        if (isTouch == false)
                        {
                            maJaugeValue.AugmenteJaugeValue(1f / 6f);
                            maJaugeValue.faitOuPasFait[18] = 1;
                            maJaugeValue.minijeuTermines++;
                            SceneManager.LoadScene("SceneLightGirl");
                        }
                    }
                }
                else if (maSerie.Count >= mesReponses.Count)
                {
                    if (fini == false)
                    {
                        Instantiate(defat, new Vector3(0, 1, 0), Quaternion.identity);
                        fini = true;
                        maJaugeValue.removeMJ(18, 5);
                    }

                    if (Input.touchCount > 0)
                    {
                        if (isTouch == false)
                        {
                            //maJaugeValue.AugmenteJaugeValue(1f / 6f);
                            maJaugeValue.faitOuPasFait[18] = 1;
                            maJaugeValue.minijeuTermines++;
                            SceneManager.LoadScene("SceneLightGirl");
                        }
                    }
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
