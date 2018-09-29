using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour {

    public GameObject[] Ingredients;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetRandomIngredient()
    {
        return Ingredients[Random.Range(0, Ingredients.Length)];
    }
}
