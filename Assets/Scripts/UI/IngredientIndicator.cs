using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientIndicator : MonoBehaviour {

    public IngredientManager IngredientManager;
    public Image Image_Ingredient;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetIngredient(Ingredient ingredient)
    {
        Image_Ingredient.sprite = ingredient.gameObject.GetComponent<SpriteRenderer>().sprite;
        Image_Ingredient.rectTransform.sizeDelta = new Vector2(ingredient.SpriteWidth, ingredient.SpriteHeight);
    }
}
