using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Help : MonoBehaviour {

    public Menu_Pause Menu_Pause;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeSelf && Input.GetButtonDown("Cancel"))
        {
            this.Hide();
        }
	}

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        Menu_Pause.HelpButtonSelectable.Select();
        this.gameObject.SetActive(false);
    }
}
