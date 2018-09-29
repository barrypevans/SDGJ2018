using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string ID;

    public void Grab(Transform hand)
    {
        transform.parent = hand;
    }

    public void Release()
    {
        transform.parent = null;
    }

}
