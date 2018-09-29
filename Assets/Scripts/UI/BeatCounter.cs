using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCounter : MonoBehaviour
{
    [SerializeField] private BeatManager _beatManager;
    [SerializeField] private Transform[] _beats;


    private void Awake()
    {
        _beatManager.RegisterBeatDelegate(BeatRecived);
    }

    private void Update()
    {
        foreach (Transform t in _beats)
            t.localScale = Vector3.Lerp(t.localScale, Vector3.one, 10f * Time.deltaTime);
    }

    private void BeatRecived(int beatNumber)
    {
        _beats[beatNumber].localScale =  new Vector3(1.5f, 1.5f, 1.5f);
    }
}
