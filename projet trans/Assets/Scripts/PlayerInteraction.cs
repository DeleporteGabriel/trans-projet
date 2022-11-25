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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            if (SceneManager.GetActiveScene().name == "SceneMap")
            {
                Vector2 deplacementVector = Input.touches[0].deltaPosition;

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
        }
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
