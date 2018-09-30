using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour {

    public IngredientManager IngredientManager;
    public GameObject IngredientPrefab;
    public int PlayerID;

	// Use this for initialization
	void Start () {
        this.SpawnIngredient();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnIngredient()
    {
        if (IngredientPrefab != null)
        {
            GameObject pObject = Instantiate(IngredientPrefab);
            Ingredient pIngredient = pObject.GetComponent<Ingredient>();
            pIngredient.IngredientSpawner = this;
            pIngredient.IngredientManager = IngredientManager;
            pIngredient._playerId = PlayerID;
            pObject.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
        }
    }
}
