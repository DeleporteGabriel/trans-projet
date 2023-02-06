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
    // Start is called before the first frame update
    void Start()
    {
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
