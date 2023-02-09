using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDifficulty : MonoBehaviour
{
    private IndestructibleObject maDifficulty;
    [SerializeField]
    private int difficulty;

    public string maScene;
    private bool activeTouch = false;

    private void Start()
    {
        maDifficulty = FindObjectOfType<IndestructibleObject>();
        if (Input.touchCount > 0) { activeTouch = true; }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var tempPosition = Input.touches[0].position;

            var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
            if (Physics.Raycast(tempRay, out var other) && activeTouch == false)
            {
                if (other.collider.GetComponent<SetDifficulty>() != null)
                {
                    maDifficulty.difficulty = other.collider.GetComponent<SetDifficulty>().difficulty;
                    var sceneNext = other.collider.GetComponent<SetDifficulty>().maScene;
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
