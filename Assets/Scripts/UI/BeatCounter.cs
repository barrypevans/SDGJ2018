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
            t.localScale = Vector3.Lerp(t.localScale, Vector3.one, 10f * Time.deltaTime);
    }

    private void BeatRecieved(int beatNumber, bool accent)
    {
        _beats[beatNumber].localScale = accent ? new Vector3(2f, 2f, 2f) : new Vector3(1.3f, 1.3f, 1.3f) ;
        if (!accent)
            _beats[beatNumber].GetComponent<Image>().color = new Color(.85f, .85f, .85f,1);
    }

    private void OnDestroy()
    {
        _beatManager.UnregisterBeatDelegate(BeatRecieved);
    }


}
