using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBloc : MonoBehaviour
{
    public Color couleurBloc;
    public SpriteRenderer sr;
    public int placeBloc;

    public List<Transform> listPosition;

    public bool isDragged = false;
    public bool isTouched = false;
    // Start is called before the first frame update
    void Start()
    {
        sr.color = couleurBloc;
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
                if (other.collider.GetComponent<TriBloc>() != null && isTouched == false)
                {
                    other.collider.GetComponent<TriBloc>().isDragged = true;
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
            if (isDragged == true)
            {
                if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out var otherB))
                {
                    if (otherB.collider.GetComponent<TriBloc>() != null)
                    {
                        var tempPlace = otherB.collider.GetComponent<TriBloc>().placeBloc;
                        otherB.collider.GetComponent<TriBloc>().placeBloc = placeBloc;
                        placeBloc = tempPlace;
                    }
                }
            }
            isDragged = false;
            isTouched = false;
            transform.position = listPosition[placeBloc].position;
        }
    }
}
