using UnityEngine;



public class BeatManager : MonoBehaviour
{
    private static readonly double Threshold = .33333;

    private double _bpm = 60;
    private double _secondCounter = 0;
    private AudioSource _audioSource;
    // double lastTime = 10 * AudioSettings.dspTime;
    int lastTime = 0;
    public delegate void BeatDelegate(int beatNumber, bool Accent);
    private event BeatDelegate BeatEvent;

    private int _currentBeat = 0;
    [SerializeField] private double _currentBeatUnQuantized = 0;
    private bool _isPlaying = true;
    [SerializeField] private RoundManager _roundManager;
    private bool[] _accentBeats = { true, false, false, false, true, false, false, false };
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        BeatEvent.Invoke(_currentBeat, _accentBeats[(int)_currentBeat]);
    }

    /// <summary>
    /// Audio callback, called ever ~20ms. About as close to the beat as we can get. 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="channels"></param>
    private void Update()
    {
        double beat = (_audioSource.time) / (.5 * 60.0 / _bpm);
        beat %= 8;
        _currentBeatUnQuantized = beat;
        beat = (int)beat;
        if (lastTime != beat)
        {
            BeatEvent.Invoke((int)beat, _accentBeats[(int)beat]);
            lastTime = (int)beat;
        }

        if (_isPlaying && !_audioSource.isPlaying)
        {
            _roundManager.EndRound();
            _isPlaying = false;
        }

    }

    public void Pause()
    {
        _isPlaying = false;
        _audioSource.Pause();
    }

    public void UnPause()
    {
        _audioSource.UnPause();
        _isPlaying = true;
    }
    public bool isOnBeat()
    {
        float bps = (float)_bpm / 60.0f;
        float diffLast = Mathf.Abs(Mathf.Floor((float)_currentBeatUnQuantized) - (float)_currentBeatUnQuantized) / bps;
        float diffNext = Mathf.Abs(Mathf.Floor((float)_currentBeatUnQuantized) - (float)_currentBeatUnQuantized) / bps;
        return diffLast < Threshold || diffNext < Threshold;
    }

    public void RegisterBeatDelegate(BeatDelegate bDelegate)
    {
        BeatEvent += bDelegate;
    }

    public void UnregisterBeatDelegate(BeatDelegate bDelegate)
    {
        BeatEvent -= bDelegate;
    }
}
