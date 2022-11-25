using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingObject : MonoBehaviour
{
    public Rigidbody rgbd;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input.gyro.enabled = true; //Active le gyro

        rgbd.AddForce(Input.gyro.userAcceleration * force);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.80f, 1.80f ), Mathf.Clamp(transform.position.y, -3.52f, 5.50f), transform.position.z);
    }
}
