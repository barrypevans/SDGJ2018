using UnityEngine;



public class BeatManager : MonoBehaviour
{
    private double _bpm = 60;
    private double _secondCounter = 0;
    private AudioSource _audioSource;
    // double lastTime = 10 * AudioSettings.dspTime;
    int lastTime =0;
    public delegate void BeatDelegate(int beatNumber);
    private event BeatDelegate BeatEvent;

    private int _currentBeat = 0;
    private bool _isPlaying = true;
    [SerializeField] private RoundManager _roundManager;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        BeatEvent.Invoke(_currentBeat);
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
        beat = (int)beat;
        if(lastTime!=beat)
        {
            BeatEvent.Invoke((int)beat);
            lastTime = (int)beat;
        }

        if(_isPlaying && !_audioSource.isPlaying)
        {
            _roundManager.EndRound();
            _isPlaying = false;
        }

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
