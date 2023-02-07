using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDefeat : MonoBehaviour
{
    public float timerMax, currentTimer;
    [SerializeField]
    private Image maJauge_;
    [SerializeField]
    private VictoireDefaite maDefaite_;
    [SerializeField]
    private int monMJ_, monPerso_;

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timerMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (maDefaite_.debut == true || maDefaite_.fini == true)
        {
            return;
        }

        currentTimer -= Time.deltaTime;
        maJauge_.fillAmount = (currentTimer/timerMax);
        if (currentTimer <= 0)
        {
            maDefaite_.Defaite(monMJ_, monPerso_);
        }
    }
}
