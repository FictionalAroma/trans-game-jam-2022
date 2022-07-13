using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;

    public static bool pausable;
    public static bool isPaused;
    private void Awake()
    {
        int numPauseScreen = FindObjectsOfType<PauseMenuManager>().Length;
        if (numPauseScreen > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Resume();
        pausable = true;
    }

    void Update()
    {
        if (pausable && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }
    public void OpenPauseMenu()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        isPaused = true;
    }
    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void QuitApllication()
    {
        Application.Quit();
        Debug.Log("Escaping");
    }


    //this is for other scripts potentially
    //i know theres probably loads of safer and simplers ways to do this but ehhhh
    public void TogglePausable() 
    {
        pausable = !pausable;
    }


    //something like this to load a different scene
    /*public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Resume();
    }*/
}
