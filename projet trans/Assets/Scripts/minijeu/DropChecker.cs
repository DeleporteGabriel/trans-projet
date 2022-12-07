using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropChecker : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;

    public int totalDrop;
    public int currentDrop;
    public int isCorrect;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalDrop == currentDrop && isCorrect == 0)
        {
            //maJaugeValue.jaugeHype += 70;
            maJaugeValue.AugmenteJaugeValue(1f / 6f);
            maJaugeValue.DragDrop = 1;
            maJaugeValue.minijeuTermines++;
            SceneManager.LoadScene("SceneLightGirl");
        }
    }
}
