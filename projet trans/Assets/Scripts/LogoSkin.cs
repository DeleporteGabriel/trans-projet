using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoSkin : MonoBehaviour
{
    public List<Sprite> mesImages;
    public SpriteRenderer sr;
    
    public int monMinijeu;
    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "SceneFraude": monMinijeu = 0; break;
            case "SceneMonnaie": monMinijeu = 1; break;
            case "SceneBadges": monMinijeu = 2; break;
            case "SceneOrdonnee": monMinijeu = 3; break;
            case "SceneBalaie": monMinijeu = 4; break;
            case "ScenePoubelle": monMinijeu = 5; break;
            case "SceneDessin": monMinijeu = 6; break;
            case "SceneCombine": monMinijeu = 7; break;
            case "ScenePlaceAuBonEndroit": monMinijeu = 8; break;
            case "SceneShaker": monMinijeu = 9; break;
            case "SceneDrag&Drop": monMinijeu = 10; break;
            case "SceneBierre": monMinijeu = 11; break;
            case "SceneRythm": monMinijeu = 12; break;
            case "SceneCourbes": monMinijeu = 13; break;
            case "SceneCibles": monMinijeu = 14; break;
            case "SceneSlider": monMinijeu = 15; break;
            case "SceneChiant": monMinijeu = 16; break;
            case "SceneSimon": monMinijeu = 17; break;
            default: monMinijeu = 0; break;
        }

        sr.sprite = mesImages[monMinijeu];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
