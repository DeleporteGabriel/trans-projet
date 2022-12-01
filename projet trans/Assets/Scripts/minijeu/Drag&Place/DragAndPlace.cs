using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndPlace: MonoBehaviour
{
    public bool isDragged = false;
    public bool isPut = false;

    public int correspondance;

    private bool isTouched = false;

    public VictoireDragAndPlace uniteCentrale;

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
            if (Physics.Raycast(tempRay, out var other))
            {
                if (other.collider.GetComponent<DragAndPlace>() != null && isTouched == false)
                {
                    other.collider.GetComponent<DragAndPlace>().isDragged = true;
                }
            }

            if (isDragged == true)
            {
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane - Camera.main.transform.position.z));
            }

            isTouched = true;
        }
        else
        {
            isDragged = false;
            isTouched = false;
        }

        if (Physics.Raycast(transform.position, new Vector3 (0, 0, 1), out var otherB))
        {
            if (otherB.collider.GetComponent<ZoneSpecifique>() != null && isDragged == false)
            {
                if (isPut == false && otherB.collider.GetComponent<ZoneSpecifique>().correspondance == correspondance)
                {
                    isPut = true;
                    uniteCentrale.currentDrop += 1;
                }
            }
            else
            {
                if (isPut == true)
                {
                    isPut = false;
                    uniteCentrale.currentDrop -= 1;
                }
            }
        }
    }
}
