using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurseurChange : MonoBehaviour
{
    private IndestructibleObject maJaugeValue;

    public float placementSlider;

    private Transform selectSlider = null;

    public float sliderMin;
    public float sliderMax;

    public SpriteRenderer sr;
    public SpriteRenderer srModel;

    private float sliderA;
    private float sliderB;
    private float sliderC;

    private float modelA;
    private float modelB;
    private float modelC;

    public float margeSlide;
    // Start is called before the first frame update
    void Start()
    {
        maJaugeValue = FindObjectOfType<IndestructibleObject>();

        modelA = Random.Range(25f, 100f)/100f;
        modelB = Random.Range(25f, 100f)/100f;
        modelC = Random.Range(25f, 100f)/100f;

        srModel.color = new Vector4(modelA, modelB, modelC, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var tempPosition = Input.touches[0].position;

            var tempRay = Camera.main.ScreenPointToRay(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane)); //crée un rayon depuis le touch 0
            if (Physics.Raycast(tempRay, out var other))
            {
                if (selectSlider == null)
                {
                    if (other.collider.GetComponent<SliderDetect>() != null)
                    {
                        selectSlider = other.transform;
                    }
                    else if (other.collider.GetComponent<SwitchScene>() != null)
                    {
                        var sceneNext = other.collider.GetComponent<SwitchScene>().maScene;

                        SceneManager.LoadScene(sceneNext);
                    }
                }
            }

            if (selectSlider != null) {
                var positionBaseX = selectSlider.position.x;

                selectSlider.position = Camera.main.ScreenToWorldPoint(new Vector3(tempPosition.x, Input.touches[0].position.y, Camera.main.nearClipPlane - Camera.main.transform.position.z));

                selectSlider.position = new Vector3(positionBaseX, Mathf.Clamp(selectSlider.position.y, sliderMin, sliderMax), selectSlider.position.z);

                if (selectSlider.position.x < -1)
                {
                    sliderA = (selectSlider.position.y - sliderMin) / (sliderMax - sliderMin);
                } else if (selectSlider.position.x < 1)
                {
                    sliderB = (selectSlider.position.y - sliderMin) / (sliderMax - sliderMin);
                } else
                {
                    sliderC = (selectSlider.position.y - sliderMin) / (sliderMax - sliderMin);
                }
            }
        }
        else
        {
            selectSlider = null;
        }

        sr.color = new Vector4(sliderA, sliderB, sliderC, 255);



        //VICTORY
        if ((sliderA > (modelA-margeSlide) && sliderA < (modelA + margeSlide)) && (sliderB > (modelB - margeSlide) && sliderB < (modelB + margeSlide)) && (sliderC > (modelC - margeSlide) && sliderC < (modelC + margeSlide)))
        {
            maJaugeValue.AugmenteJaugeValue(1f/6f);
            maJaugeValue.ColorsTest = 1;
            maJaugeValue.minijeuTermines++;
            SceneManager.LoadScene("SceneGuichetier");
        }

    }
}
