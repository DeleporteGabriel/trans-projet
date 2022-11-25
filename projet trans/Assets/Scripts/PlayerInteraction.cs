using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public float camMinX;
    public float camMaxX;
    public float camMinY;
    public float camMaxY;

    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    public float force;

    private bool activeTouch = false;

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
            if (Physics.Raycast(tempRay, out var other) && activeTouch == false)
            {
                var sceneNext = other.collider.GetComponent<SwitchScene>().maScene;

                SceneManager.LoadScene(sceneNext);
            }

            if (SceneManager.GetActiveScene().name == "SceneMap")
            {
                Vector2 deplacementVector = Input.touches[0].deltaPosition;

                Debug.Log("bonjour bg");

                Camera.main.transform.position += new Vector3(-deplacementVector.x * force * (Camera.main.orthographicSize / 8), -deplacementVector.y * force * (Camera.main.orthographicSize / 8), 0);
                Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, camMinX, camMaxX), Mathf.Clamp(Camera.main.transform.position.y, camMinY, camMaxY), -10);
            }

            if ((Input.touchCount > 1) && (SceneManager.GetActiveScene().name == "SceneMap"))
            {
                var tempTouchA = Input.touches[0];
                var tempTouchB = Input.touches[1];

                Vector2 touchAPrev = tempTouchA.position - tempTouchA.deltaPosition;
                Vector2 touchBPrev = tempTouchB.position - tempTouchB.deltaPosition;

                float prevMagnitude = (touchAPrev - touchBPrev).magnitude;
                float currentMagnitude = (tempTouchA.position - tempTouchB.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                zoom(difference * 0.005f);
            }
            activeTouch = true;

        } else 
        { 
            activeTouch = false;
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

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
