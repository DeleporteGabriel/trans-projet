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
        if(Input.touchCount>0)
        {
            var tempPosition = Input.touches[0].position;

            var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
            if (Physics.Raycast(tempRay, out var other))
            {
                var sceneNext = other.collider.GetComponent<SwitchScene>().maScene;

                SceneManager.LoadScene(sceneNext);
            }
            if (Input.touchCount>1)
            {
                var tempMoveTouchA = Input.touches[0];
                var tempMoveTouchB = Input.touches[1];

                Vector2 touchAPrev = tempMoveTouchA.position - tempMoveTouchA.deltaPosition;
                Vector2 touchBPrev = tempMoveTouchB.position - tempMoveTouchB.deltaPosition;

                float prevMagnitude = (touchAPrev - touchBPrev).magnitude;

                if ()
                {
                    Debug.Log("ça zooooooom");
                }
        }


        /*
         * 
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
        }*/
    }
}
