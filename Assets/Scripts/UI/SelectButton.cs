using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectButton : Selectable, ISubmitHandler
{
    [SerializeField] GameObject Outline;
    [SerializeField] EasyTween easyTweenstart;
    [SerializeField] public UnityEvent onClick;
    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        Outline.SetActive(true);
        Outline.GetComponent<Image>().material.SetFloat("_BreatheEffect", 1);
        GetComponent<Image>().material.SetFloat("_BreatheEffect", 1);
        easyTweenstart.ChangeSetState(false);
        easyTweenstart.OpenCloseObjectAnimation();
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        Outline.SetActive(false);
        Outline.GetComponent<Image>().material.SetFloat("_BreatheEffect", 0);
        GetComponent<Image>().material.SetFloat("_BreatheEffect", 0);
        easyTweenstart.ChangeSetState(true);
        easyTweenstart.OpenCloseObjectAnimation();
    }

    public void OnSubmit(BaseEventData eventData)
    {
        onClick.Invoke();
    }
}
