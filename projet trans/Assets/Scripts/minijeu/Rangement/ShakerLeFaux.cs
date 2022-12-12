using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakerLeFaux : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;

    public float force;
    public Rigidbody rgbd;
    public float shakingMax;

    public float shakeNumber;
    public float shakeVictoire;

    public int positionLigne;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
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

        rgbd.velocity = new Vector3 ((Input.gyro.rotationRate.z) * -force, 0, 0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.60f), 0, 0);

        if (transform.position.x > 1.4f && positionLigne != 2) 
        {
            positionLigne = 2;
            shakeNumber++;
        }
        else if (transform.position.x <= -1.3f && positionLigne != 1)
        {
            positionLigne = 1;
            shakeNumber++;
        }

        if (shakeNumber == shakeVictoire)
        {
            maJaugeValue.AugmenteJaugeValue(1f / 6f);
            maJaugeValue.ShakeBranlette = 1;
            maJaugeValue.minijeuTermines++;
            SceneManager.LoadScene("SceneMap");
        }
    }
}
