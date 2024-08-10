using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject GUI;
    
    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            UpdatePauseState();
        }
    }
    
    void UpdatePauseState()
    {
        pausePanel.SetActive(isPaused);
        GUI.SetActive(!isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
