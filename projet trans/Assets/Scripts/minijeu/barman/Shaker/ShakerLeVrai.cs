using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakerLeVrai : MonoBehaviour
{
    private bool isTouch = false;

    private IndestructibleObject maJaugeValue;

    public float force;
    public Rigidbody rgbd;
    public float shakingMax;
    public Transform up, down;
    public SpriteRenderer mousse;
    public List<Sprite> mousseEtape;

    [SerializeField]
    private VictoireDefaite maFin;

    public GameObject bulle;
    public Transform parent;
    private float t;

    private bool pointAdd = true;

    public float shakeNumber;
    public float shakeVictoire;

    private int diffulctLevel;

    [SerializeField]
    private TimerDefeat monTimer;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
        diffulctLevel = maJaugeValue.difficulty;

        if (diffulctLevel == 1)
        {
            monTimer.timerMax *= 1;
            monTimer.currentTimer = monTimer.timerMax;
            shakeVictoire = 10;
        }
        else if (diffulctLevel == 2)
        {
            monTimer.timerMax *= 0.8f;
            monTimer.currentTimer = monTimer.timerMax;
            shakeVictoire = 15;
        }
        else if (diffulctLevel == 3)
        {
            monTimer.timerMax *= 0.5f;
            monTimer.currentTimer = monTimer.timerMax;
            shakeVictoire = 20;
        }

        mousse.sprite = mousseEtape[0];

        if (Input.touchCount > 0) { isTouch = true; }
    }

    // Update is called once per frame
    void Update()
    {

        Input.gyro.enabled = true;

       // rgbd.velocity = Vector3.up * Input.gyro.userAcceleration.magnitude*Mathf.Sign(Input.gyro.userAcceleration.z);
        t += Input.gyro.userAcceleration.magnitude*force*Time.deltaTime;
        transform.position = Vector3.Lerp(down.position, up.position, (Mathf.Sin(t)+1)/2);

        if (((Mathf.Sin(t)+1)/2) <= 0.05 || ((Mathf.Sin(t) + 1) / 2) >= 0.95)
        {
            if (pointAdd == true) {
                pointAdd = false;
                shakeNumber++;

                Vector3 randomSpawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-4f, 0f),1);

                Instantiate(bulle, randomSpawnPosition, Quaternion.identity, parent);
            }
        }
        else
        {
            pointAdd = true;
        }


        if (shakeNumber == shakeVictoire/4)
        {

            mousse.sprite = mousseEtape[0];

        }

        if (shakeNumber == shakeVictoire / 2)
        {

            mousse.sprite = mousseEtape[1];

        }
        if (shakeNumber == shakeVictoire-3)
        {

            mousse.sprite = mousseEtape[2];

        }

        if (shakeNumber >= shakeVictoire)
        {
            maFin.Victoire(10, 3);
        }

        //rgbd.velocity = new Vector3 (0, (Input.gyro.rotationRate.z + compensation) * force, 0);

        /*if (rgbd.velocity.y > shakingMax)
        {
            Debug.Log("bravo mon poto");
        }*/
    }
}
