using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndestructibleObject : MonoBehaviour
{
    public float jaugeHype;

    public int DragDrop;
    public int Cibles;
    public int DragPlace;

    public int minijeuTermines;

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
            SceneManager.LoadScene("SceneMap");
        }
    }
}
