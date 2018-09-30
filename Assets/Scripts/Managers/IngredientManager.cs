using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour {

    public GameObject[] Ingredients;
    public GameObject[] IngredientSpawns_Left;
    public GameObject[] IngredientSpawns_Right;
    public GameObject CurrentIngredient_Left;
    public GameObject CurrentIngredient_Right;
    public IngredientIndicator IngredientIndicator_Left;
    public IngredientIndicator IngredientIndicator_Right;
    public int IngredientMatchScoreGain;
    public int IngredientMismatchedScoreLoss;
    public int IngredientMissPotScoreLoss;

    // Use this for initialization
    void Start () {
        this.SetIngredient();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetIngredient(int iPlayerIndex = -1)
    {
        if (iPlayerIndex == 0 || iPlayerIndex == -1)
        {
            CurrentIngredient_Left = GetRandomIngredient();
            IngredientIndicator_Left.SetIngredient(CurrentIngredient_Left.GetComponent<Ingredient>());
        }
        if (iPlayerIndex == 1 || iPlayerIndex == -1)
        {
            CurrentIngredient_Right = GetRandomIngredient();
            IngredientIndicator_Right.SetIngredient(CurrentIngredient_Right.GetComponent<Ingredient>());
        }
    }

    public GameObject GetRandomIngredient()
    {
        return Ingredients[Random.Range(0, Ingredients.Length)];
    }
}
