using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakerLeVrai : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;

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
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Input.gyro.enabled = true;

       // rgbd.velocity = Vector3.up * Input.gyro.userAcceleration.magnitude*Mathf.Sign(Input.gyro.userAcceleration.z);
        t += Input.gyro.userAcceleration.magnitude*force;
        transform.position = Vector3.Lerp(down.position, up.position, (Mathf.Sin(t)+1)/2);

        if (((Mathf.Sin(t)+1)/2) == 0 || ((Mathf.Sin(t) + 1) / 2) == 1)
        {
            shakeNumber++;
        }

        if (shakeNumber == shakeVictoire)
        {
            //maJaugeValue.jaugeHype += 70;
            maJaugeValue.AugmenteJaugeValue(0.15f);
            maJaugeValue.ShakeBranlette = 1;
            maJaugeValue.minijeuTermines++;
            SceneManager.LoadScene("SceneMap");
        }

        //rgbd.velocity = new Vector3 (0, (Input.gyro.rotationRate.z + compensation) * force, 0);

        /*if (rgbd.velocity.y > shakingMax)
        {
            Debug.Log("bravo mon poto");
        }*/
    }
}
