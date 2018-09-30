using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDelayManager : MonoBehaviour {

    public GameObject Menu_Instructions;
    private PauseManager PauseManager;

	// Use this for initialization
	void Start () {
        PauseManager = GetComponent<PauseManager>();
        PauseManager.PauseGame(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            Menu_Instructions.SetActive(false);
            PauseManager.UnPauseGame();
        }

    }
}
