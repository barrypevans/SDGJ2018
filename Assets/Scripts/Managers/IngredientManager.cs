using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour {

    public GameObject[] Ingredients;
    public IngredientIndicator IngredientIndicatorLeft;
    public IngredientIndicator IngredientIndicatorRight;

    // Use this for initialization
    void Start () {
        IngredientIndicatorLeft.SetIngredient(GetRandomIngredient().GetComponent<Ingredient>());
        IngredientIndicatorRight.SetIngredient(GetRandomIngredient().GetComponent<Ingredient>());
    }

    // Update is called once per frame
    void Update () {
		
	}

    public GameObject GetRandomIngredient()
    {
        return Ingredients[Random.Range(0, Ingredients.Length)];
    }
}
