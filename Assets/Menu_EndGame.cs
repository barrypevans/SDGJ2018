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
    private SpriteRenderer m_pSpriteRenderer;

    // Use this for initialization
    void Start ()
    {
        m_pSpriteRenderer = GetComponent<SpriteRenderer>();
        int iPlayer1Score = PlayerPrefs.GetInt("Player1Score");
        int iPlayer2Score = PlayerPrefs.GetInt("Player2Score");
        Text_Score_Left.text = iPlayer1Score.ToString();
        Text_Score_Right.text = iPlayer2Score.ToString();

        if (iPlayer1Score > iPlayer2Score)
        {
            m_pSpriteRenderer.sprite = Player1Background;
        }
        else if (iPlayer1Score < iPlayer2Score)
        {
            m_pSpriteRenderer.sprite = Player2Background;
        }
        else
        {
            m_pSpriteRenderer.sprite = TieBackground;
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
