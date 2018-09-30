using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAudio : MonoBehaviour, ISelectHandler, ISubmitHandler
{
    public void OnSelect(BaseEventData eventData)
    {
        AudioService.Instance.PlayAudio("ui_hover");
    }

    public void OnSubmit(BaseEventData eventData)
    {
        AudioService.Instance.PlayAudio("ui_select");
    }
}
