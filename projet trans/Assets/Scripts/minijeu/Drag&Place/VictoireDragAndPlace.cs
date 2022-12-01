using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoireDragAndPlace : MonoBehaviour
{
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
            maJaugeValue.jaugeHype += 70;
            maJaugeValue.DragPlace = 1;
            maJaugeValue.minijeuTermines++;
            SceneManager.LoadScene("SceneMap");
        }
    }
}
