using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour {

    public GameObject[] Ingredients;
    public GameObject[] IngredientSpawns_Left;
    public GameObject[] IngredientSpawns_Right;
    public IngredientIndicator IngredientIndicator_Left;
    public IngredientIndicator IngredientIndicator_Right;

    // Use this for initialization
    void Start () {
        IngredientIndicator_Left.SetIngredient(GetRandomIngredient().GetComponent<Ingredient>());
        IngredientIndicator_Right.SetIngredient(GetRandomIngredient().GetComponent<Ingredient>());
    }

    // Update is called once per frame
    void Update () {
		
	}

    public GameObject GetRandomIngredient()
    {
        return Ingredients[Random.Range(0, Ingredients.Length)];
    }
}
