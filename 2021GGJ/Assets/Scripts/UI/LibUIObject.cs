using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibUIObject : MonoBehaviour
{
    public float moveRate = 0.1f;
    public RectTransform targetTr;
    public RectTransform tr;
    public Button button;

    private void Start()
    {
        tr = GetComponent<RectTransform>();
    }

    public bool isMoving;

    public void SetPos(RectTransform target)
    {
        tr.localPosition = target.localPosition;
    }

    public void SetButton(bool state)
    {
        button.interactable = state;
    }

    public void SetButtonActive(bool state)
    {
        button.gameObject.SetActive(state);
    }

    public void SetImage(Sprite sprite)
    {
        button.image.sprite = sprite;
    }

    public void SetTarget(RectTransform target, float moveRate = 0.1f)
    {
        targetTr = target;
        this.moveRate = moveRate;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 mypos = tr.localPosition;
            Vector3 tpos = targetTr.localPosition;
            if ((mypos - tpos).sqrMagnitude < 0.01f)
            {
                tr.localPosition = tpos;
                isMoving = false;
            }
            else
            {
                tr.localPosition += (tpos - mypos) * moveRate;
            }
        }
    }

}
