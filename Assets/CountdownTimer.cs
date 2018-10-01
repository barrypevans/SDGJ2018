using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public enum State
    {
        Start,
        ScaleIn,
        Hold,
        ScaleOut,
        Finished
    }

    public BeatManager BeatManager;
    public int StartCountdownTime;
    public float ScaleInTime;
    public float HoldTime;
    public float ScaleOutTime;
    private Text m_pText_Timer;
    private float m_fElapsedTime = 0.0f;
    private State m_eState = State.Start;

	// Use this for initialization
	void Start () {
        m_pText_Timer = GetComponent<Text>();
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update () {
        float fTimeRemaining = BeatManager.GetTimeRemaining();

        if (fTimeRemaining <= StartCountdownTime)
        {
            m_fElapsedTime += Time.deltaTime;

            m_pText_Timer.text = ((int)fTimeRemaining).ToString();

            if (m_eState == State.Start)
            {
                m_eState = State.ScaleIn;
                m_fElapsedTime = StartCountdownTime - fTimeRemaining;
            }
            switch (m_eState)
            {
                case State.ScaleIn:
                    {
                        float fScale = m_fElapsedTime / ScaleInTime;
                        transform.localScale = new Vector3(fScale, fScale);
                        if (m_fElapsedTime  >= ScaleInTime)
                        {
                            m_fElapsedTime = m_fElapsedTime - ScaleInTime;
                            m_eState = State.Hold;
                        }
                        break;
                    }
                case State.Hold:
                    {
                        if (m_fElapsedTime >= HoldTime)
                        {
                            m_fElapsedTime = m_fElapsedTime - HoldTime;
                            m_eState = State.ScaleOut;
                        }
                        break;
                    }
                case State.ScaleOut:
                    {
                        float fScale = Mathf.Lerp(1, 0, m_fElapsedTime / ScaleOutTime);
                        transform.localScale = new Vector3(fScale, fScale);
                        if (m_fElapsedTime >= ScaleOutTime)
                        {
                            if (fTimeRemaining <= 0.0f)
                            {
                                m_eState = State.Finished;
                            }
                            else
                            {
                                m_eState = State.ScaleIn;
                            }
                            m_fElapsedTime = m_fElapsedTime - ScaleOutTime;
                        }
                        break;
                    }
            }

        }
	}
}
