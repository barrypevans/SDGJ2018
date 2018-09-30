using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Main : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnClick_StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClick_Credits()
    {
        SceneManager.LoadScene("Menu_Credits");
    }

    public void OnClick_Quit()
    {
        Application.Quit();
    }
}
