using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmManager : MonoBehaviour
{
    [SerializeField] private BeatManager _beatManager;
    [SerializeField] private int _playerIndex = 0;
    [SerializeField] private bool _side = false;

    private Rigidbody2D _rigidBody;
    [SerializeField] private Ingredient _acitiveIngredient;
    [SerializeField] private Ingredient _potentialIngredient;



    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _beatManager.RegisterBeatDelegate(BeatRecieved);
    }

    private void Update()
    {
        Vector2 velocityDirection = new Vector2(
                                    Input.GetAxis("Horizontal " + (_side ? "Left " : "Right ") + (_playerIndex + 1)), 
                                    Input.GetAxis("Vertical "   + (_side ? "Left " : "Right ") + (_playerIndex + 1)));
        if (Mathf.Abs(velocityDirection.magnitude) > .1f)
            _rigidBody.velocity = velocityDirection.normalized * 15;
    }

    private void BeatRecieved(int beatNumber)
    {
        KeyCode key = _side ? KeyCode.Joystick1Button6 : KeyCode.Joystick1Button7 ;
        if (Input.GetKey(key + _playerIndex*19))
        {
            _acitiveIngredient = _potentialIngredient;
            if(null != _acitiveIngredient)
                _acitiveIngredient.Grab(transform);
        }
        else
        {
            if (null != _acitiveIngredient)
                _acitiveIngredient.Release();
            _acitiveIngredient = null;
            _potentialIngredient = null;
        }
    }

    private void OnDestroy()
    {
        _beatManager.UnregisterBeatDelegate(BeatRecieved);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ingredient overlapedIngredient = other.gameObject.GetComponent<Ingredient>();
        if (null != overlapedIngredient)
            _potentialIngredient = overlapedIngredient;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Ingredient overlapedIngredient = collision.gameObject.GetComponent<Ingredient>();
        if (_potentialIngredient != overlapedIngredient)
            _potentialIngredient = null;

    }

}
