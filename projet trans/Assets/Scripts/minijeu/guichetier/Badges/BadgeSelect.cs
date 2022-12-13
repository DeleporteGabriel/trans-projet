using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeSelect : MonoBehaviour
{
    public Sprite badgeColor;
    public int badgeNumber;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = badgeColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
