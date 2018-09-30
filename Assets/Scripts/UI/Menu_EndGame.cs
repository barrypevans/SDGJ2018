using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_EndGame : MonoBehaviour {

    public Sprite Player1Background;
    public Sprite Player2Background;
    public Sprite TieBackground;
    public Text Text_Score_Left;
    public Text Text_Score_Right;
    public SpriteRenderer SpriteRenderer_Title;

    // Use this for initialization
    void Start ()
    {
        AudioService.Instance.PlayAudio("fanfare");
        int iPlayer1Score = PlayerPrefs.GetInt("Player1Score");
        int iPlayer2Score = PlayerPrefs.GetInt("Player2Score");
        Text_Score_Left.text = iPlayer1Score.ToString();
        Text_Score_Right.text = iPlayer2Score.ToString();

        if (iPlayer1Score > iPlayer2Score)
        {
            SpriteRenderer_Title.sprite = Player1Background;
        }
        else if (iPlayer1Score < iPlayer2Score)
        {
            SpriteRenderer_Title.sprite = Player2Background;
        }
        else
        {
            SpriteRenderer_Title.sprite = TieBackground;
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
