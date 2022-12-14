using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DraggedObject : MonoBehaviour
{
    public List<Sprite> listeIngredients;
    public List<Sprite> bonIngredient;
    public List<Sprite> mauvaisIngredient;

    public SpriteRenderer sr;

    public bool isDragged = false;
    public bool isGood = false;
    public bool isPut = false;

    private bool isTouched = false;

    public DropChecker uniteCentrale;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < listeIngredients.Count; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                bonIngredient.Add(listeIngredients[i]);
            }
            else
            {
                mauvaisIngredient.Add(listeIngredients[i]);
            }
        }
        if(isGood == false)
        {
            sr.sprite = mauvaisIngredient[Random.Range(0,mauvaisIngredient.Count)];
        }
        else
        {
            sr.sprite = bonIngredient[Random.Range(0, bonIngredient.Count)];
        }




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var tempPosition = Input.touches[0].position;

            var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //cr�e un rayon depuis le touch 0
            if (Physics.Raycast(tempRay, out var other))
            {
                if (other.collider.GetComponent<DraggedObject>() != null && isTouched == false)
                {
                    other.collider.GetComponent<DraggedObject>().isDragged = true;
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
            if (otherB.collider.GetComponent<ZoneDetect>() != null && isDragged == false)
            {
                if (isPut == false)
                {
                    isPut = true;
                    uniteCentrale.currentDrop += 1;
                    if (isGood == false)
                    {
                        uniteCentrale.isCorrect += 1;
                    }
                }
            }
            else
            {
                if (isPut == true)
                {
                    isPut = false;
                    uniteCentrale.currentDrop -= 1;
                    if (isGood == false)
                    {
                        uniteCentrale.isCorrect -= 1;
                    }
                }
            }
        }
    }
}