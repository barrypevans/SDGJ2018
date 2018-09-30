using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpresionManager : MonoBehaviour
{
    public GameObject[] EyesOpen;
    public GameObject[] EyesBlink;
    private void Start()
    {
        StartCoroutine(Co_Blink());
    }

    private IEnumerator Co_Blink()
    {
        while (true)
        {
            foreach (GameObject g in EyesOpen)
                g.SetActive(false);
            foreach (GameObject g in EyesBlink)
                g.SetActive(true);
            yield return new WaitForSeconds(.05f);
            foreach (GameObject g in EyesOpen)
                g.SetActive(true);
            foreach (GameObject g in EyesBlink)
                g.SetActive(false);
            yield return new WaitForSeconds(Random.Range(1.9f, 5));
        }
    }
}
