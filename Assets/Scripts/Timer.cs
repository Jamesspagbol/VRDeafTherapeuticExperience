using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    enum SkyStates { StateNormal, StateLightOrange, StateDarkOrange, StateDarkBlue, StateBlack}
    SkyStates CurrentSkyState;
    public Text TimerText;
    public float TimeLeft;
    private float StartingTime = 150f;
    private Camera SkyCam;
    public bool TimerIsOn;

    void Start()
    {
        SkyCam = GetComponent<Camera>();
        TimerIsOn = false;
        TimeLeft = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
            if (TimeLeft > 0.0f)
            {
                TimerText.text = "Time:" + TimeLeft;
                TimeLeft = TimeLeft - Time.deltaTime;
                switch (CurrentSkyState)
                {
                    case SkyStates.StateNormal:
                        if (TimeLeft >= 120.0f)
                        {
                            SkyCam.backgroundColor = new Color(49f / 255f, 77f / 255f, 121f / 255f);
                        }
                        else if (TimeLeft < 120.0f)
                        {
                            CurrentSkyState = SkyStates.StateLightOrange;
                        }
                        break;
                    case SkyStates.StateLightOrange:
                        if (TimeLeft >= 90.0f)
                        {
                            SkyCam.backgroundColor = new Color(222f / 255f, 168f / 255f, 62f / 255f);
                        }
                        else if (TimeLeft < 90.0f)
                        {
                            CurrentSkyState = SkyStates.StateDarkOrange;
                        }
                        break;
                    case SkyStates.StateDarkOrange:
                        if (TimeLeft >= 60.0f)
                        {
                            SkyCam.backgroundColor = new Color(179f / 255f, 122f / 255f, 10f / 255f);
                        }
                        else if (TimeLeft < 60.0f)
                        {
                            CurrentSkyState = SkyStates.StateDarkBlue;
                        }
                        break;
                    case SkyStates.StateDarkBlue:
                        if (TimeLeft >= 30.0f)
                        {
                            SkyCam.backgroundColor = new Color(13 / 255f, 6f / 255f, 171f / 255f);
                        }
                        else if (TimeLeft < 30.0f)
                        {
                            CurrentSkyState = SkyStates.StateBlack;
                        }
                        break;
                    case SkyStates.StateBlack:
                        if (TimeLeft >= 0.0f)
                        {
                            SkyCam.backgroundColor = new Color(0f / 255f, 0f / 255f, 0f / 255f);
                        }
                        else if (TimeLeft < 0.0f)
                        {
                            TimerText.text = "GameOver";
                        }
                        break;
                }
            }
    }
}
