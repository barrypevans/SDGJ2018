using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private int _ingredientID = 0;

    public void Grab(Transform hand)
    {
        transform.parent = hand;
    }

    public void Release()
    {
        transform.parent = null;
    }

}
