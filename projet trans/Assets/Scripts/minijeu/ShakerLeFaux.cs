using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerLeFaux : MonoBehaviour
{
    public float force;
    public Rigidbody rgbd;
    public float shakingMax;

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
        /*t += Input.gyro.userAcceleration.magnitude * force;
        transform.position = Vector3.Lerp(down.position, up.position, (Mathf.Sin(t) + 1) / 2);

        if (Mathf.Sin(t) == 0 || Mathf.Sin(t) == 1)
        {
            shakeNumber++;
        }

        if (shakeNumber == shakeVictoire)
        {
            Debug.Log("ON A GAGNÉ");
        }*/

        rgbd.velocity = new Vector3 ((Input.gyro.rotationRate.z) * force, 0, 0);
    }
}
