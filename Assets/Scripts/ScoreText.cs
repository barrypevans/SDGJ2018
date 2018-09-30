using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private float curScore = 0;
    [SerializeField] private bool playerIndex;
    [SerializeField] private RoundManager _roundManager;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        curScore = Mathf.Lerp(curScore, playerIndex ? _roundManager._p1Score : _roundManager._p2Score, 10 * Time.deltaTime);
        _text.text = (Mathf.CeilToInt(curScore)).ToString();
    }

}
