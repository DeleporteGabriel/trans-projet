using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndestructibleObject : MonoBehaviour
{
    public float jaugeHype;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("SceneMap");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
