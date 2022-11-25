using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string maScene;
    private bool activeTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var tempPosition = Input.touches[0].position;

            var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
            if (Physics.Raycast(tempRay, out var other) && activeTouch == false)
            {
                if (other.collider.GetComponent<SwitchScene>() != null)
                {
                    var sceneNext = other.collider.GetComponent<SwitchScene>().maScene;

                    SceneManager.LoadScene(sceneNext);
                }
            }

            activeTouch = true;
        }
        else
        {
            activeTouch = false;
        }

    }
}
