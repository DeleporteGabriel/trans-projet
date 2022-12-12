using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakingObject : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;

    public Rigidbody rgbd;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Input.gyro.enabled = true; //Active le gyro

        rgbd.velocity = new Vector3( Input.gyro.rotationRate.y, Input.gyro.rotationRate.x,0) * force;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.80f, 1.80f ), Mathf.Clamp(transform.position.y, -3.52f, 5.50f), 0);

        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out var otherB))
        {
            if (otherB.collider.GetComponent<ZoneDetect>() != null)
            {
                //maJaugeValue.jaugeHype += 70;
                maJaugeValue.AugmenteJaugeValue(1f/6f);
                maJaugeValue.GyroSpace = 1;
                maJaugeValue.minijeuTermines++;
                SceneManager.LoadScene("SceneDA");
            }
        }
    }
}
