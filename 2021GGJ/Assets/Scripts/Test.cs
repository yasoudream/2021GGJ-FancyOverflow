using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject img;

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.SetActive(false);
    }
    //public override void OnPointerEnter(PointerEventData eventData)
    //{
    //    base.OnPointerEnter(eventData);
    //    img.SetActive(true);
    //}

    //public override void OnPointerExit(PointerEventData eventData)
    //{
    //    base.OnPointerExit(eventData);
    //    img.SetActive(false);
    //}
}
