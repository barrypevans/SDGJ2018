using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ingredient : MonoBehaviour
{
    public string ID;
    public int _playerId;
    public int SpriteWidth;
    public int SpriteHeight;
    public IngredientSpawner IngredientSpawner;
    public IngredientManager IngredientManager;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Grab(Transform hand)
    {
        transform.parent = hand;
        transform.localPosition = Vector3.zero;
        _rigidbody.simulated = false;
        _rigidbody.constraints = RigidbodyConstraints2D.None;
    }

    public void Release()
    {
        transform.parent = null;
        _rigidbody.simulated = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pot")
        {
            if (_playerId == 0)
            {
                if (IngredientManager.CurrentIngredient_Left.GetComponent<Ingredient>().ID == ID)
                {
                    RoundManager.Instance._p1Score += IngredientManager.IngredientMatchScoreGain;
                    IngredientManager.SetIngredient();
                }
                else
                {
                    RoundManager.Instance._p1Score -= IngredientManager.IngredientMismatchedScoreLoss;
                }
            }
            else
            {
                if (IngredientManager.CurrentIngredient_Right.GetComponent<Ingredient>().ID == ID)
                {
                    RoundManager.Instance._p2Score += IngredientManager.IngredientMatchScoreGain;
                    IngredientManager.SetIngredient();
                }
                else
                {
                    RoundManager.Instance._p2Score -= IngredientManager.IngredientMismatchedScoreLoss;
                }
            }

            if (IngredientSpawner != null)
            {
                IngredientSpawner.SpawnIngredient();
            }

            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "table")
        {
            if (_playerId == 0)
            {
                RoundManager.Instance._p1Score -= IngredientManager.IngredientMissPotScoreLoss;
            }
            else
            {
                RoundManager.Instance._p2Score -= IngredientManager.IngredientMissPotScoreLoss;
            }
            if (IngredientSpawner != null)
            {
                IngredientSpawner.SpawnIngredient();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ArmManager armManager = collision.gameObject.GetComponent<ArmManager>();
        if (null != armManager)
            armManager.PotentialIngredientEnter(this);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ArmManager armManager = collision.gameObject.GetComponent<ArmManager>();
        if (null != armManager)
            armManager.PotentialIngredientExit(this);
    }
}
