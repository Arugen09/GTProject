using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    public Slider slider;
    public Image image;
    
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerBehaviour>().hasSword)
        {
            slider.value = (0.7f - GameObject.Find("Player").GetComponent<PlayerBehaviour>().coolDownTime)/0.7f;
        }
        else
        {
            slider.value = (2f - GameObject.Find("Player").GetComponent<PlayerBehaviour>().coolDownTime)/2f;
            
        }

        if (slider.value == 1)
        {
            image.color = new Color(0.425f, 1f, 0.375f, 1f);
        }
        else
        {
            image.color = new Color(0.375f, 0.575f, 1f, 1f);
        }
        
    }
}
