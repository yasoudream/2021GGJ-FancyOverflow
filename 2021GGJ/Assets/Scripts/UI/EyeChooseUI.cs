using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeChooseUI : MonoBehaviour
{
    public List<EyeChooseObject> uiobjs;
    public void SetData(List<CardObject> cards)
    {
        int count = Random.Range(1, cards.Count);
        if (count > uiobjs.Count)
            count = uiobjs.Count;

        int start = Random.Range(0, cards.Count);
        int uistart = Random.Range(0, uiobjs.Count);

        foreach (var obj in uiobjs)
        {
            obj.gameObject.SetActive(false);
        }

        for (int i = 0; i < count; i++)
        {
            uiobjs[(uistart + i) % uiobjs.Count].SetData(cards[(i + start) % cards.Count]);
            uiobjs[(uistart + i) % uiobjs.Count].gameObject.SetActive(true);
        }
    }

    public void OnClick_Back()
    {
        this.gameObject.SetActive(false);
    }
}
