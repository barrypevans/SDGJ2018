using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Main : MonoBehaviour {

    public GameObject Title;
    public GameObject StartGame;
    public GameObject Credits;
    public GameObject Quit;
    public float TimeTitleOnScreen;
    private float m_fTotalElapsedTime = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (m_fTotalElapsedTime < TimeTitleOnScreen)
        {
            m_fTotalElapsedTime += Time.deltaTime;

            if (m_fTotalElapsedTime >= TimeTitleOnScreen)
            {
                Title.SetActive(false);
                StartGame.SetActive(true);
                StartGame.GetComponent<Selectable>().Select();
                Credits.SetActive(true);
                Quit.SetActive(true);
            }
        }
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
