using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSimon : MonoBehaviour
{

    public Color myColor;
    public SpriteRenderer sr;
    public int quelSimon;

    public float timer;
    public float timerMax;

    public bool isWhite = false;
    [SerializeField]
    private SimonManager monManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWhite == true)
        {
            timer += Time.deltaTime;
            if (timer >= timerMax)
            {
                timer = 0;
                isWhite = false;
                sr.color = myColor;
                monManager.mesModeles[quelSimon].color = new Vector4(1, 1, 1, 0.5f);
            }
        }
    }
}
