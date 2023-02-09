using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeonDeplacement : MonoBehaviour
{
    public Vector3 basePosition;
    private Vector3 anciennePosition;
    private Vector3 newPosition;
    private float t_;
    private int timer_;

    private IndestructibleObject hypePeon;
    // Start is called before the first frame update
    void Start()
    {
        hypePeon = FindObjectOfType<IndestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hypePeon.isMinigameWin == false)
        {
            return;
        }
        timer_++;
        t_ += 0.01f;
        if (timer_%60  == 0)
        {
            t_ = 0;
            anciennePosition = transform.position;
            newPosition = new Vector3(basePosition.x + Random.Range(-0.4f, 0.4f), basePosition.y + Random.Range(-0.2f, 0.2f), basePosition.z);
        }
        transform.position = Vector3.Lerp(anciennePosition, newPosition, t_);
    }
}
