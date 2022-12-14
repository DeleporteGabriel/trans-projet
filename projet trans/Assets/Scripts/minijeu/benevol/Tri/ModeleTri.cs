using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeleTri : MonoBehaviour
{
    public List<GameObject> mesPositions;
    public int positionModele;

    public TriOrdre monOrdre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(2.6f, mesPositions[monOrdre.ordreCorrect[positionModele]].transform.position.y, -1);
    }
}
