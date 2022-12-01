using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DraggedObject : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;
    public bool isDragged = false;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var tempPosition = Input.touches[0].position;

            var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
            if (Physics.Raycast(tempRay, out var other))
            {
                if (other.collider.GetComponent<DraggedObject>() != null)
                {
                    other.collider.GetComponent<DraggedObject>().isDragged = true;
                }
            }

            if (isDragged == true)
            {
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane - Camera.main.transform.position.z));
            }
        }
        else
        {
            isDragged = false;
        }

        if (Physics.Raycast(transform.position, new Vector3 (0, 0, 1), out var otherB))
        {
            if (otherB.collider.GetComponent<ZoneDetect>() != null && isDragged == false)
            {
                maJaugeValue.jaugeHype += 70;
                SceneManager.LoadScene("SceneMap");
            }
        }
    }
}
