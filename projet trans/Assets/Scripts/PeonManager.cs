using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeonManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> mesPeons_;
    [SerializeField]
    private GameObject monPrefabsPeon_;

    private int nombrePeon;
    private IndestructibleObject nombrePeonCheck;

    // Update is called once per frame
    void Start()
    {
        nombrePeonCheck = FindObjectOfType<IndestructibleObject>();
        nombrePeon = nombrePeonCheck.minijeuGagne*20;

        for (int i = 0; i < nombrePeon; i++)
        {
            var monPeonX = Random.Range(-2.26f, 2.6f);
            var monPeonY = Random.Range(-4f, 6f);
            var monPeonPosition = new Vector3(monPeonX, monPeonY, 2f + monPeonY / 50f);
            var monPeon = Instantiate(monPrefabsPeon_, monPeonPosition, Quaternion.identity);
            monPeon.transform.parent = transform;
            monPeon.GetComponent<PeonDeplacement>().basePosition = monPeonPosition;
            mesPeons_.Add(monPeon);
        }
    }
}
