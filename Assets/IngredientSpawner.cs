using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour {

    public string IngredientID;
    public int PlayerID;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnIngredient(GameObject pIngredientPrefab)
    {
        if (pIngredientPrefab != null)
        {
            GameObject pObject = Instantiate(pIngredientPrefab);
            Ingredient pIngredient = pObject.GetComponent<Ingredient>();
            pIngredient.IngredientSpawner = this;
            pIngredient._playerId = PlayerID;
            pObject.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
        }
    }
}
