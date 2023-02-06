using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoireDefaite : MonoBehaviour
{
    [SerializeField]
    private GameObject victor, defat, intro;
    private GameObject monIntro;
    public bool fini = false, activeTouch = false, debut = true;

    private IndestructibleObject maJaugeValue;

    [SerializeField]
    private int activeMJ;
    [SerializeField]
    private string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        monIntro = Instantiate(intro, new Vector3(0, 1, 0), Quaternion.identity);
        if (Input.touchCount > 0) { activeTouch = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if (debut == true)
        {
            if (Input.touchCount > 0 && activeTouch == false)
            {
                debut = false;
                Destroy(monIntro);
            }
        }

        if (fini == true)
        {
            if (Input.touchCount > 0)
            {
                if (activeTouch == false)
                {
                    maJaugeValue.faitOuPasFait[activeMJ] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene(nextScene);
                }
            }
        }
        
        if (Input.touchCount == 0) { activeTouch = false; } else { activeTouch = true; }
    }

    public void Victoire(int MJ, int Perso)
    {
        if (fini == false)
        {
            Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
            fini = true;
            maJaugeValue.isMinigameWin = true;
            maJaugeValue.removeMJ(MJ, Perso);
        }
    }

    public void Defaite(int MJ, int Perso)
    {
        if (fini == false)
        {
            Instantiate(defat, new Vector3(0, 1, 0), Quaternion.identity);
            fini = true;
            maJaugeValue.isMinigameWin = false;
            maJaugeValue.removeMJ(MJ, Perso);
        }
    }
}
