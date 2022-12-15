using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelPart : MonoBehaviour
{
    public List<Sprite> graphics;
    public int currentGraphics;

    public int rightPannel;

    public SpriteRenderer sr;

    private Animator animObject;
    // Start is called before the first frame update
    void Start()
    {
        animObject = GetComponent<Animator>();

        currentGraphics = Random.Range(0, graphics.Count);
        while (currentGraphics == rightPannel)
        {
            currentGraphics = Random.Range(0, graphics.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        sr.sprite = graphics[currentGraphics];
    }

    public void onTapTrigger()
    {
        animObject.SetTrigger("onTap");
    }
}
