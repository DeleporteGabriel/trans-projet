using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDefeat : MonoBehaviour
{
    [SerializeField]
    private float timerMax_, currentTimer_;
    [SerializeField]
    private Image maJauge_;
    [SerializeField]
    private VictoireDefaite maDefaite_;
    [SerializeField]
    private int monMJ_, monPerso_;

    // Start is called before the first frame update
    void Start()
    {
        currentTimer_ = timerMax_;
    }

    // Update is called once per frame
    void Update()
    {
        if (maDefaite_.debut == true || maDefaite_.fini == true)
        {
            return;
        }

        currentTimer_ -= Time.deltaTime;
        maJauge_.fillAmount = (currentTimer_/timerMax_);
        if (currentTimer_ <= 0)
        {
            maDefaite_.Defaite(monMJ_, monPerso_);
        }
    }
}
