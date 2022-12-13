using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoireDragAndPlace : MonoBehaviour
{
    private bool isTouch = false;
    private bool fini = false;
    public GameObject victor;

    private IndestructibleObject maJaugeValue;

    public int totalDrop;
    public int currentDrop;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalDrop == currentDrop)
        {
            if (fini == false)
            {
                Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                fini = true;
                maJaugeValue.removeMJ(9, 2);
            }

            if (Input.touchCount > 0)
            {
                if (isTouch == false)
                {
                    maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[9] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneDA");
                }
                isTouch = true;
            }
            else { isTouch = false; }
        }
    }
}
