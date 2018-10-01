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
    private Rigidbody2D _rigidbody;
    private BeatManager _beatManager;
    public ExpresionManager expressionManager;
    private bool _grabBonusFlag;
    private bool _releaseBonus;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _beatManager = GameObject.FindObjectOfType<BeatManager>();
    }

    public void Grab(Transform hand, ParticleSystem starParticle = null)
    {
        _grabBonusFlag = true;
        
        AudioService.Instance.PlayAudio(ID);
        transform.parent = hand;
        transform.localPosition = Vector3.zero;
        _rigidbody.simulated = false;
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        transform.localScale = new Vector3(2, 2, 2);

        if (_beatManager.isOnBeat()&&!_grabBonusFlag)
        {
            string ingID = _playerId == 0 ? IngredientManager.Instance.CurrentIngredient_Left.GetComponent<Ingredient>().ID : IngredientManager.Instance.CurrentIngredient_Right.GetComponent<Ingredient>().ID;
            if (ingID != ID) return;
            //print("Grabbed On Beat!");
            if(null != starParticle)
                starParticle.Play();
            PopUp25();
            BonusPoints();
        }
    }

    public void Release(ParticleSystem starParticle = null)
    {
        transform.parent = null;
        _rigidbody.simulated = true;

        if (_beatManager.isOnBeat()&&!_releaseBonus)
        {
            string ingID = _playerId == 0 ? IngredientManager.Instance.CurrentIngredient_Left.GetComponent<Ingredient>().ID : IngredientManager.Instance.CurrentIngredient_Right.GetComponent<Ingredient>().ID;
            if (ingID != ID) return;
            //print("Released On Beat!");
            if (null != starParticle)
                starParticle.Play();
           
            _releaseBonus = true;
        }
    }

    private void BonusPoints()
    {
        
        if (_playerId == 0)
        {
            RoundManager.Instance._p1Score += IngredientManager.Instance.IngredientMatchScoreBonus;
        }
        else
        {
            RoundManager.Instance._p2Score += IngredientManager.Instance.IngredientMatchScoreBonus;
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
                if (IngredientManager.Instance.CurrentIngredient_Left.GetComponent<Ingredient>().ID == ID)
                {
                    if (!_releaseBonus)
                        RoundManager.Instance._p1Score += IngredientManager.Instance.IngredientMatchScoreGain;
                    else
                    {
                        PopUp25();
                        RoundManager.Instance._p1Score += IngredientManager.Instance.IngredientMatchScoreGain + IngredientManager.Instance.IngredientMatchScoreBonus;
                    }
                    IngredientManager.Instance.SetIngredient(_playerId);
                    AudioService.Instance.PlayAudio("correct");
                    PopUp50();
                }
                else
                {
                    RoundManager.Instance._p1Score -= IngredientManager.Instance.IngredientMismatchedScoreLoss;
                    AudioService.Instance.PlayAudio("mistake");
                    if (null != expressionManager)
                        expressionManager.SetSurprised(1);
                }
            }
            else
            {
                if (IngredientManager.Instance.CurrentIngredient_Right.GetComponent<Ingredient>().ID == ID)
                {
                    if (!_releaseBonus)
                        RoundManager.Instance._p2Score += IngredientManager.Instance.IngredientMatchScoreGain;
                    else
                    {
                        RoundManager.Instance._p2Score += IngredientManager.Instance.IngredientMatchScoreGain + IngredientManager.Instance.IngredientMatchScoreBonus;
                        PopUp25();
                    }
                    IngredientManager.Instance.SetIngredient(_playerId);
                    AudioService.Instance.PlayAudio("correct");
                    PopUp50();
                }
                else
                {
                    RoundManager.Instance._p2Score -= IngredientManager.Instance.IngredientMismatchedScoreLoss;
                    AudioService.Instance.PlayAudio("mistake");
                    expressionManager.SetSurprised(1);
                }
            }

            if (IngredientSpawner != null)
            {
                IngredientManager.Instance.MarkSpawnerAvailableAndSpawnIngredientAtRandomSpawner(IngredientSpawner, this.ID);
            }

            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "table")
        {
            if (_playerId == 0)
            {
                RoundManager.Instance._p1Score -= IngredientManager.Instance.IngredientMissPotScoreLoss;
            }
            else
            {
                RoundManager.Instance._p2Score -= IngredientManager.Instance.IngredientMissPotScoreLoss;
            }
            if (IngredientSpawner != null)
            {
                IngredientManager.Instance.MarkSpawnerAvailableAndSpawnIngredientAtRandomSpawner(IngredientSpawner, this.ID);
            }
            AudioService.Instance.PlayAudio("mistake");
            expressionManager.SetSurprised(1);
            PopUp15();
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

    private void PopUp15()
    {
        var obj = Instantiate(Resources.Load("score-pop-15"),Vector3.zero,Quaternion.identity) as GameObject;
        obj.transform.position = transform.position;
        obj.transform.position += new Vector3(0, 0, -1);
    }

    private void PopUp25()
    {
        var obj = Instantiate(Resources.Load("score-pop+25"),Vector3.zero,Quaternion.identity) as GameObject;
        obj.transform.position = transform.position;
        obj.transform.position += new Vector3(0, 0, -1);
    }

    private void PopUp30()
    {
        var obj = Instantiate(Resources.Load("score-pop-30"),Vector3.zero,Quaternion.identity) as GameObject;
        obj.transform.position = transform.position;
        obj.transform.position += new Vector3(0, 0, -1);
    }

    private void PopUp50()
    {
        var obj = Instantiate(Resources.Load("score-pop+50"), Vector3.zero, Quaternion.identity) as GameObject;
        obj.transform.position = transform.position;
        obj.transform.position += new Vector3(0, 0, -1);
    }

}
