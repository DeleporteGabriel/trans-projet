using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleCount : MonoBehaviour
{

    public int totalCible;
    public int cibleTrouver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (totalCible == cibleTrouver)
        {
            Debug.Log("Bravo tu as tout trouvé");
        }
    }
}
