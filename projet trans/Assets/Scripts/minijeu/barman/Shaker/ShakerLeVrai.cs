using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakerLeVrai : MonoBehaviour
{
    private bool isTouch = false;
    private bool fini = false;
    private bool debut = true;
    public GameObject victor;
    public GameObject intro;

    private GameObject monIntro;

    private IndestructibleObject maJaugeValue;

    public float force;
    public Rigidbody rgbd;
    public float shakingMax;
    public Transform up, down;
    public SpriteRenderer mousse;
    public List<Sprite> mousseEtape;

    public GameObject bulle;
    public Transform parent;
    private float t;

    private bool pointAdd = true;

    public float shakeNumber;
    public float shakeVictoire;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();
        mousse.sprite = mousseEtape[0];

        monIntro = Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (debut == true)
        {
            if (Input.touchCount > 0)
            {
                debut = false;
                Destroy(monIntro);
            }
            return;
        }

        Input.gyro.enabled = true;

       // rgbd.velocity = Vector3.up * Input.gyro.userAcceleration.magnitude*Mathf.Sign(Input.gyro.userAcceleration.z);
        t += Input.gyro.userAcceleration.magnitude*force;
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
        if (shakeNumber == shakeVictoire-4)
        {

            mousse.sprite = mousseEtape[2];

        }

        if (shakeNumber == shakeVictoire)
        {
            if (fini == false)
            {
                Instantiate(victor, new Vector3(0, 1, 0), Quaternion.identity);
                fini = true;
                maJaugeValue.removeMJ(10, 3);
            }

            if (Input.touchCount > 0)
            {
                if (isTouch == false)
                {
                    maJaugeValue.AugmenteJaugeValue(1f / 6f);
                    maJaugeValue.faitOuPasFait[10] = 1;
                    maJaugeValue.minijeuTermines++;
                    SceneManager.LoadScene("SceneBarman");
                }
                isTouch = true;
            }
            else { isTouch = false; }
        }

        //rgbd.velocity = new Vector3 (0, (Input.gyro.rotationRate.z + compensation) * force, 0);

        /*if (rgbd.velocity.y > shakingMax)
        {
            Debug.Log("bravo mon poto");
        }*/
    }
}
