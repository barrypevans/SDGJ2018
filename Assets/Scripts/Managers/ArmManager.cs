using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmManager : MonoBehaviour
{
    private static float ArmLength = 5.0f;

    [SerializeField] private BeatManager _beatManager;
    [SerializeField] private int _playerIndex = 0;
    [SerializeField] private bool _side = false;

    private Rigidbody2D _rigidBody;
    [SerializeField] private Ingredient _acitiveIngredient;
    [SerializeField] private Ingredient _potentialIngredient;
    [SerializeField] private Transform _armRoot;
    [SerializeField] private ParticleSystem _starParticles;


    private bool _grabbing;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        if (_beatManager != null)
            _beatManager.RegisterBeatDelegate(BeatRecieved);
    }

    private void Update()
    {
        Vector2 velocityDirection = new Vector2(
                                    Input.GetAxis("Horizontal " + (_side ? "Left " : "Right ") + (_playerIndex + 1)), 
                                    Input.GetAxis("Vertical "   + (_side ? "Left " : "Right ") + (_playerIndex + 1)));
        if (Mathf.Abs(velocityDirection.magnitude) > .1f)
            _rigidBody.MovePosition(Vector3.Lerp(transform.position,_armRoot.position + new Vector3(velocityDirection.x, velocityDirection.y,0)* ArmLength, 10*Time.deltaTime));

        KeyCode key = _side ? KeyCode.Joystick1Button6 : KeyCode.Joystick1Button7;

        if (Input.GetKey(key + _playerIndex * 20))
        {
            if (null != _acitiveIngredient) return;

            _acitiveIngredient = _potentialIngredient;
            if (null != _acitiveIngredient)
                _acitiveIngredient.Grab(transform, _starParticles);
        }
        else
        {
            if (null != _acitiveIngredient)
                _acitiveIngredient.Release(_starParticles);
            _acitiveIngredient = null;
            _potentialIngredient = null;
        }
    }

    private void BeatRecieved(int beatNumber, bool accent)
    {
        if (!accent) return;

       
    }

    private void OnDestroy()
    {
        if (_beatManager != null)
            _beatManager.UnregisterBeatDelegate(BeatRecieved);
    }

    public void PotentialIngredientEnter(Ingredient ingredient)
    {
        if (null != ingredient)
            _potentialIngredient = ingredient;
    }

    public void PotentialIngredientExit(Ingredient ingredient)
    {
        if (_potentialIngredient != ingredient)
            _potentialIngredient = null;    
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hand")
        {
            AudioService.Instance.PlayAudio("high_five",true);
        }
    }


}
