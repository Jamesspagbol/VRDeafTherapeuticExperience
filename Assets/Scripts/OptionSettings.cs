using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSettings : MonoBehaviour
{
    private float TimerSliderValue;
    public GameObject TimerObject;
    public GameObject Slider;
    public bool StartTimer;
   
    private void SetTimer (float Timer)
    {
        DontDestroyOnLoad(Slider);
        TimerSliderValue = GameObject.Find("TimerSlider").GetComponent<Slider>().value;
        if(TimerSliderValue == 1)
        {
            TimerObject.GetComponent<Timer>().TimerIsOn = true;
        }
        else if (TimerSliderValue == 0)
        {
            TimerObject.GetComponent<Timer>().TimerIsOn = false;
        }
    }
}
