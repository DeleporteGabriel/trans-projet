using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoCible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, new Vector3(0, 0, -1), out var other))
        {
            var monTempo = other.collider.GetComponent<TempoRythm>();
            if (monTempo != null)
            {
                if (monTempo.tempoState != 3)
                {
                    monTempo.tempoState = 1;
                }
            }
        }
    }
}
