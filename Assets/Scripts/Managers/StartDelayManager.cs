using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDelayManager : MonoBehaviour {

    public GameObject Menu_Instructions;
    private PauseManager PauseManager;
    private bool m_bStarted;

	// Use this for initialization
	void Start () {
        PauseManager = GetComponent<PauseManager>();
        PauseManager.PauseGame(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!m_bStarted && Input.anyKeyDown)
        {
            m_bStarted = true;
            Menu_Instructions.SetActive(false);
            PauseManager.UnPauseGame();
        }

    }
}
