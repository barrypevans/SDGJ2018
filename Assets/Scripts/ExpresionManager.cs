using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpresionManager : MonoBehaviour
{
    public GameObject[] EyesOpen;
    public GameObject[] EyesBlink;
    public GameObject MouthNormal;
    public GameObject MouthSurprised;
    private void Start()
    {
        StartCoroutine(Co_Blink());
    }


    public void SetSurprised(float duration)
    {
        MouthNormal.SetActive(false);
        MouthSurprised.SetActive(true);
        Co_ReturnToNormal(duration);
    }

    private IEnumerator Co_ReturnToNormal(float duration)
    {
        yield return new WaitForSeconds(duration);
        MouthNormal.SetActive(true);
        MouthSurprised.SetActive(false);
    }

    private IEnumerator Co_Blink()
    {
        while (true)
        {
            foreach (GameObject g in EyesOpen)
                g.SetActive(false);
            foreach (GameObject g in EyesBlink)
                g.SetActive(true);
            yield return new WaitForSeconds(.02f);
            foreach (GameObject g in EyesOpen)
                g.SetActive(true);
            foreach (GameObject g in EyesBlink)
                g.SetActive(false);
            yield return new WaitForSeconds(Random.Range(1.9f, 3.6f));
        }
    }
}
