using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public EventSystem EventSystem;
    public Menu_Pause Menu_Pause;
    public BeatManager BeatManager;
    private bool m_bIsPaused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Options"))
        {
            if (m_bIsPaused)
            {
                this.UnPauseGame();
            }
            else
            {
                this.PauseGame();
            }
        }
		
	}

    public void PauseGame(bool bOpenPauseMenu = true)
    {
        m_bIsPaused = true;
        Time.timeScale = 0.0f;
        if (BeatManager!= null)
        {
            BeatManager.Pause();
        }
        if (Menu_Pause != null && bOpenPauseMenu)
        {
            Menu_Pause.gameObject.SetActive(true);
            if (EventSystem != null)
            {
                Menu_Pause.FirstSelectable.Select();
            }
        }
    }

    public void UnPauseGame()
    {
        m_bIsPaused = false;
        Time.timeScale = 1.0f;
        if (BeatManager != null)
        {
            BeatManager.UnPause();
        }
        if (Menu_Pause != null)
        {
            Menu_Pause.Resume();
            if (EventSystem != null)
            {
                EventSystem.SetSelectedGameObject(null);
            }
        }
    }
}
