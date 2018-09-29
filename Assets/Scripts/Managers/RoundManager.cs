using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        print("End Round");
    }

}
