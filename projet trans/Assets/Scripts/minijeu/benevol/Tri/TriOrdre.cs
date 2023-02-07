using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriOrdre : MonoBehaviour
{
    [SerializeField]
    private VictoireDefaite maFin;

    public List<int> ordreCorrect;
    public List<TriBloc> listBlocs;

    public int winCounter;

    private int diffulctLevel;
    [SerializeField]
    private TimerDefeat monTimer;
    private IndestructibleObject maDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        maDifficulty = FindObjectOfType<IndestructibleObject>();
        diffulctLevel = maDifficulty.difficulty;

        if (diffulctLevel == 1)
        {
            monTimer.timerMax *= 1;
            monTimer.currentTimer = monTimer.timerMax;
        }
        else if (diffulctLevel == 2)
        {
            monTimer.timerMax *= 0.8f;
            monTimer.currentTimer = monTimer.timerMax;
        }
        else if (diffulctLevel == 3)
        {
            monTimer.timerMax *= 0.5f;
            monTimer.currentTimer = monTimer.timerMax;
        }

        for (int i = 0; i < ordreCorrect.Count; i++)
        {
            int temp = ordreCorrect[i];
            int randomIndex = Random.Range(i, ordreCorrect.Count);
            ordreCorrect[i] = ordreCorrect[randomIndex];
            ordreCorrect[randomIndex] = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (maFin.debut == true || maFin.fini == true)
        {
            return;
        }

        winCounter = 0;
        for (var i = 0; i < ordreCorrect.Count; i++)
        {
            if (ordreCorrect[i] == listBlocs[i].placeBloc)
            {
                winCounter++;
            }
        }
        if (winCounter >= ordreCorrect.Count)
        {
            maFin.Victoire(4, 1);
        }
    }
}
