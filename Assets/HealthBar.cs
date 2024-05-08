using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public CanvasRenderer cr;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (GameObject.Find("CameraScript").GetComponent<CameraScript>().isFollowing && !GameObject.Find("CameraScript").GetComponent<CameraScript>().isInBossRoom)
        {
            cr.SetAlpha(0);
        }
        else
        {
           cr.SetAlpha(255);
        }
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

}
