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
        //transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update () {
        float fTimeRemaining = BeatManager.GetTimeRemaining();

        m_pText_Timer.text = ((int)fTimeRemaining).ToString();
        if (fTimeRemaining <= StartCountdownTime)
        {
            m_fElapsedTime += Time.deltaTime;

            if (m_eState == State.Start)
            {
                m_eState = State.ScaleIn;
                m_fElapsedTime = StartCountdownTime - fTimeRemaining;
            }
            switch (m_eState)
            {
                case State.ScaleIn:
                    {
                        float fScale = Mathf.Lerp(0, ScaleInTime, m_fElapsedTime);
                        transform.localScale = new Vector3(fScale, fScale);
                        if (m_fElapsedTime  >= ScaleInTime)
                        {
                            m_eState = State.Hold;
                            m_fElapsedTime = 0.0f;
                        }
                        break;
                    }
                case State.Hold:
                    {
                        if (m_fElapsedTime >= HoldTime)
                        {
                            m_eState = State.ScaleOut;
                            m_fElapsedTime = 0.0f;
                        }
                        break;
                    }
                case State.ScaleOut:
                    {
                        float fScale = Mathf.Lerp(ScaleOutTime, 0, m_fElapsedTime);
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
                            m_fElapsedTime = 0.0f;
                        }
                        break;
                    }
                case State.Finished:
                    {
                        break;
                    }
            }

        }
	}
}
