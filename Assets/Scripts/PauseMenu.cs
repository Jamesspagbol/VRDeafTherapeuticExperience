using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool ExperienceIsPaused = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (ExperienceIsPaused)
            {
                ResumeExperience();
            } else
            {
                PauseExperience();
            }
        }
    }

     public void ResumeExperience()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        ExperienceIsPaused = false;
    }

    void PauseExperience()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        ExperienceIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        ExperienceIsPaused = false;
    }

    public void QuitExperience()
    {
        Application.Quit();
    }

    public void ResetExperience()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        ExperienceIsPaused = false;
    }
}
