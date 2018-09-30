using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_EndGame : MonoBehaviour {

    public Image Background;
    public Sprite Player1Background;
    public Sprite Player2Background;
    public Sprite TieBackground;

    // Use this for initialization
    void Start ()
    {
        int iPlayer1Score = PlayerPrefs.GetInt("Player1Score");
        int iPlayer2Score = PlayerPrefs.GetInt("Player2Score");

        if (iPlayer1Score > iPlayer2Score)
        {
            Background.sprite = Player1Background;
        }
        else if (iPlayer1Score < iPlayer2Score)
        {
            Background.sprite = Player2Background;
        }
        else
        {
            Background.sprite = TieBackground;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Menu_Main");
        }
		
	}
}
