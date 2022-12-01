using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerLeVrai : MonoBehaviour
{
    public float force;
    public Rigidbody rgbd;
    public float shakingMax;
    public Transform up, down;
    private float t;

    public float shakeNumber;
    public float shakeVictoire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input.gyro.enabled = true;

       // rgbd.velocity = Vector3.up * Input.gyro.userAcceleration.magnitude*Mathf.Sign(Input.gyro.userAcceleration.z);
        t += Input.gyro.userAcceleration.magnitude*force;
        transform.position = Vector3.Lerp(down.position, up.position, (Mathf.Sin(t)+1)/2);

        if (Mathf.Sin(t) == 0 || Mathf.Sin(t) == 1)
        {
            shakeNumber++;
        }

        if (shakeNumber == shakeVictoire)
        {
            Debug.Log("ON A GAGN�");
        }

        //rgbd.velocity = new Vector3 (0, (Input.gyro.rotationRate.z + compensation) * force, 0);

        /*if (rgbd.velocity.y > shakingMax)
        {
            Debug.Log("bravo mon poto");
        }*/
    }
}
