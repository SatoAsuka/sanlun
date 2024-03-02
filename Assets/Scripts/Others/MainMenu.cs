using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Map");
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
