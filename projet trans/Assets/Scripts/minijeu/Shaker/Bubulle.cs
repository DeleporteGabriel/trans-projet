using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubulle : MonoBehaviour
{
    public float alphaBulle;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        alphaBulle = Mathf.Clamp(alphaBulle + 0.01f, 0, 1);

        sr.color = new Vector4(1, 1, 1, alphaBulle);

        transform.position += new Vector3(0, 0.01f, 0);


        if (transform.position.y >= 3.70)
        {
            sr.enabled = false;
        }
    }
}
