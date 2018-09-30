using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public int _p1Score;
    public int _p2Score;

    public static RoundManager Instance;

    private void Awake()
    {
        if (null == Instance)
            Instance = this;
        else
            Destroy(this);
    }

    public void EndRound()
    {
        PlayerPrefs.SetInt("Player1Score", _p1Score);
        PlayerPrefs.SetInt("Player2Score", _p2Score);
        SceneManager.LoadScene("Menu_EndGame");
    }

}
