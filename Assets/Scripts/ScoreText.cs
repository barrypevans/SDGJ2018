using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int curScore = 0;
    [SerializeField] private bool playerIndex;
    [SerializeField] private RoundManager _roundManager;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = ((int)Mathf.Lerp(curScore, playerIndex ? _roundManager._p1Score : _roundManager._p2Score, 10 * Time.deltaTime)).ToString();
    }

}
