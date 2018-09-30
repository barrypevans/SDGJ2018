using UnityEngine.UI;
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
            t.localScale = Vector3.Lerp(t.localScale, Vector3.one*2, 10f * Time.deltaTime);
    }

    private void BeatRecieved(int beatNumber, bool accent)
    {
        _beats[beatNumber].localScale = accent ? new Vector3(5.5f, 5.5f, 5.5f) : new Vector3(2.5f, 2.5f, 2.5f) ;
        if (!accent)
            _beats[beatNumber].GetComponent<Image>().color = new Color(.85f, .85f, .85f,1);
    }

    private void OnDestroy()
    {
        _beatManager.UnregisterBeatDelegate(BeatRecieved);
    }


}
