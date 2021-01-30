using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeChooseObject : MonoBehaviour
{
    public Button button;
    public CardObject card;

    public void SetData(CardObject card)
    {
        this.card = card;
        button.image.sprite = card.cardTexture;
        button.interactable = true;
    }

    public LibsUI libsui;

    public void OnClick()
    {
        libsui.GetOrgan_eye(card);
    }
}
