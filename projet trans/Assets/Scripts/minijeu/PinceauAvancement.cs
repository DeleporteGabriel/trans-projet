using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinceauAvancement : MonoBehaviour
{

    public float speedBrush;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input.gyro.enabled = true;

        var deplacement = new Vector3(0, -1*Input.gyro.rotationRate.z, 0) * speedBrush;

        transform.position += deplacement;

        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out var otherB))
        {
            if (otherB.collider.GetComponent<ZoneDetect>() != null)
            {
                Debug.Log("OH NON TU PERDS");
            }
        }
    }
}
