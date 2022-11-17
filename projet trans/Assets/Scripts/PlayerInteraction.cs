using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == "SceneTest")
            {
                SceneManager.LoadScene("SceneTest2");
            }
            else
            {
                SceneManager.LoadScene("SceneTest");
            }
        }
    }
}
