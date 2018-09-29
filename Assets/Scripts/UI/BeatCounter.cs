using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCounter : MonoBehaviour
{
    [SerializeField] private BeatManager _beatManager;
    [SerializeField] private Transform[] _beats;


    private void Awake()
    {
        _beatManager.RegisterBeatDelegate(BeatRecieved);
    }

    private void Update()
    {
        foreach (Transform t in _beats)
            t.localScale = Vector3.Lerp(t.localScale, Vector3.one, 10f * Time.deltaTime);
    }

    private void BeatRecieved(int beatNumber)
    {
        _beats[beatNumber].localScale =  new Vector3(1.5f, 1.5f, 1.5f);
    }

    private void OnDestroy()
    {
        _beatManager.UnregisterBeatDelegate(BeatRecieved);
    }


}
