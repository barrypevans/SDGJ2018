using UnityEngine;



public class BeatManager : MonoBehaviour
{
    private static readonly double Threshold = .33333;

    [SerializeField] private double _bpm = 60;
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
    public bool[] _accentBeats = { true, false, true, false, true, false, true, false };
    public float _timeElapsed = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if(null!= BeatEvent)
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
        _timeElapsed += Time.deltaTime;
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
        float diffNext = Mathf.Abs(Mathf.Ceil((float)_currentBeatUnQuantized) - (float)_currentBeatUnQuantized) / bps;
        int nextBeat = (int)Mathf.Ceil((float)_currentBeatUnQuantized);
        nextBeat = nextBeat >= 8 ? 0 : nextBeat;
        return (diffLast < Threshold && _accentBeats[(int)Mathf.Floor((float)_currentBeatUnQuantized)]) || (diffNext < Threshold && _accentBeats[nextBeat]);
    }

    public void RegisterBeatDelegate(BeatDelegate bDelegate)
    {
        BeatEvent += bDelegate;
    }

    public void UnregisterBeatDelegate(BeatDelegate bDelegate)
    {
        BeatEvent -= bDelegate;
    }

    public float GetTimeRemaining()
    {
        return _audioSource.clip.length - _timeElapsed;
    }
}
