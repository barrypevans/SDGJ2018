using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Pause : MonoBehaviour {

    public Selectable FirstSelectable;
    public PauseManager PauseManager;
    public GameObject Menu_Volume;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick_Resume()
    {
        PauseManager.UnPauseGame();
    }

    public void OnClick_Help()
    {

    }

    public void OnClick_Volume()
    { 
        Menu_Volume.SetActive(true);
    }

    public void OnClick_Quit()
    {
        SceneManager.LoadScene("Menu_Main");
    }
}
