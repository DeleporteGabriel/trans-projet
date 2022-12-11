using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelPart : MonoBehaviour
{
    public List<Color> graphics;
    public int currentGraphics;

    public int rightPannel;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        currentGraphics = Random.Range(0, 6);
        while (currentGraphics == rightPannel)
        {
            currentGraphics = Random.Range(0, 6);
        }
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = graphics[currentGraphics];
    }
}
