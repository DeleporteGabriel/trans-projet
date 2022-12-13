using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCounterAction : MonoBehaviour
{
    public int frameActionSpace;
    private FramedUpdateMonoBehaviour[] allFrameUpdateMB;
    // Start is called before the first frame update
    void Start()
    {
        allFrameUpdateMB = FindObjectsOfType<FramedUpdateMonoBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount%frameActionSpace == 0)
        {
            foreach (var item in allFrameUpdateMB)
            {
                item.OnEveryXFrameUpdate();
            }
        }
    }
}
