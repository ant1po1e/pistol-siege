using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject mainPanel;
    public GameObject buttonsParent;
    private bool settingPanelActive;

    public Animator transitionAnim;
    
    void Start()
    {
        settingPanel.SetActive(false);
    }

    void Update()
    {
        if (settingPanelActive == true)
        {
            settingPanel.SetActive(true);
            buttonsParent.SetActive(false);
        }
        else 
        {
            settingPanel.SetActive(false);
            buttonsParent.SetActive(true);
        }
    }

    public void Action(string name)
    {
        switch (name)
        {
            case "Setting": settingPanelActive = !settingPanelActive; break;
            case "Exit": Application.Quit(); break;
        }
    }

    public void LaodScene(string sceneName)
    {
        StartCoroutine(TransitionLoadScene(sceneName));
    }

    IEnumerator TransitionLoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("Transition");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
        mainPanel.SetActive(false);
    }
}
