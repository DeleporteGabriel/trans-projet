using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndestructibleObject : MonoBehaviour
{
    [Range(0.1f,100f)]
    public float jaugeHypeMax;
    private float currentJaugeHype =0;

    public int DragDrop;
    public int Cibles;
    public int DragPlace;
    public int GyroSpace;
    public int ShakeBranlette;
    public int ColorsTest;

    public int minijeuTermines;

    public JaugeParametre jp;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "FirstScene" && (Input.touchCount > 0))
        {
            SceneManager.LoadScene("SceneIntro");
        }
    }

    public float GetJaugeRatio() => currentJaugeHype / jaugeHypeMax;


    public void ChangeJaugeHype()
    {
        if(jp == null)
        {
            jp = FindObjectOfType<JaugeParametre>();
        }
        currentJaugeHype = Mathf.Clamp(currentJaugeHype, 0, jaugeHypeMax);
        jp.UpdateJauge(GetJaugeRatio());
    }

    public void AugmenteJaugeValue(float addValue)
    {
        currentJaugeHype += addValue;
    }
}
