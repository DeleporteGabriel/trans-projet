using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Dessin : FramedUpdateMonoBehaviour
{

    public LineRenderer linePrefab;  //Entrer le prefab qui contient le LR

    private LineRenderer currentLineRenderer; //Le LR qu'on utilise actuellement
    private List<LineRenderer> allLineRenderer;// Tous les LR qu'on a crée (pottentielement additioner les positions avec un foreach)

    private bool shouldDraw;
    private int lineIndex;
    int i;
    
    void Start()
    {
        allLineRenderer = new List<LineRenderer>(); //On initialise la liste car sinon ça ne marche pas
    }

    public override void OnEveryXFrameUpdate()
    {
        if(shouldDraw)
        {
            if(currentLineRenderer.positionCount<=0 || Vector3.Distance(currentLineRenderer.GetPosition(lineIndex-1), transform.position) >= 1) //Si on doit dessiner ET que soit cest le premier points soit on est suffisament eloigné du dernier point on en crée un nouveau 
            {
                currentLineRenderer.positionCount = lineIndex + 1; // mise a jour de la taille de la liste de points
                currentLineRenderer.SetPosition(lineIndex, transform.position); // on ajoute la position actuelle en tant que nouveau point 
                lineIndex++;
            }
        }
    }
    void Update()
    {

        if (Input.touchCount>0)
        {
            var mousPos = Input.touches[0].position;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousPos.x, mousPos.y, 10)); //chopper la position du doigt

            if(shouldDraw == false)
            {
                //Reset d'une nouvelle ligne
                lineIndex = 0;
                shouldDraw = true;
                currentLineRenderer = Instantiate(linePrefab,transform);
                currentLineRenderer.positionCount = 0;
                allLineRenderer.Add(currentLineRenderer);
            }
        }
        else
        {
            if(shouldDraw==true)
            {
                i++;
                if(i>=2)
                {
                    //Appel du check de dessin 
                    CheckForSimilarities();
                }
            }
            shouldDraw = false;
        }
    }

    public void IntensityLight(float x, float y)
    {

    }

    public bool CheckForSimilarities()
    {
        var errors = 0;

        // A remplacer par une addition de tous les points + une comparaison avec un dessin prefait 
        var first = new Vector3[allLineRenderer[0].positionCount];
        allLineRenderer[0].GetPositions(first); 


        var second = new Vector3[allLineRenderer[1].positionCount];
        allLineRenderer[1].GetPositions(second);

        for (int j = 0; j <Mathf.Min(first.Length,second.Length); j++)
        {
            if(Vector3.Distance(first[j], second[j])>0.5f)
            {
                errors ++;
            }
        }

        Debug.Log(errors);

        return errors>=5;
    }
}
