using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMonsterUI : MonoBehaviour
{
    public CardObject card;

    public Image cardImg;
    public Text cardName;
    public Text cardDes;


    public void SetData(CardObject card)
    {
        this.card = card;
        cardName.text = card.cardName;
        cardDes.text = card.cardDescription;
        cardImg.sprite = card.cardTexture;
        this.gameObject.SetActive(true);
    }

    public void OnClick_Get()
    {
        card.OnUse();
        card = null;
        this.gameObject.SetActive(false);
    }
}
