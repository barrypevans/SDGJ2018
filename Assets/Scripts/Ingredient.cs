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
    private BeatManager _beatManager;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _beatManager = GameObject.FindObjectOfType<BeatManager>();
    }

    public void Grab(Transform hand)
    {
        AudioService.Instance.PlayAudio(ID);
        transform.parent = hand;
        transform.localPosition = Vector3.zero;
        _rigidbody.simulated = false;
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        transform.localScale = new Vector3(2, 2, 2);

        if (_beatManager.isOnBeat())
        {
            print("Grabbed On Beat!");
            BonusPoints();
        }
    }

    public void Release()
    {
        transform.parent = null;
        _rigidbody.simulated = true;

        if (_beatManager.isOnBeat())
        {
            print("Released On Beat!");
            BonusPoints();
        }
    }

    private void BonusPoints()
    {
        if (_playerId == 0)
        {
            RoundManager.Instance._p1Score += IngredientManager.IngredientMatchScoreGain;
        }
        else
        {
            RoundManager.Instance._p2Score += IngredientManager.IngredientMatchScoreGain;
        }
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 20 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pot")
        {
            if (_playerId == 0)
            {
                if (IngredientManager.CurrentIngredient_Left.GetComponent<Ingredient>().ID == ID)
                {
                    RoundManager.Instance._p1Score += IngredientManager.IngredientMatchScoreGain;
                    IngredientManager.SetIngredient(_playerId);
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
                    IngredientManager.SetIngredient(_playerId);
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

            AudioService.Instance.PlayAudio("correct");

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
            AudioService.Instance.PlayAudio("mistake");
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
