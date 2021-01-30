using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObjectUI : MonoBehaviour
{
    public CardObject card;

    public Button cardButton;
    public Image cardImg;
    public Text nameText;

    public void SetData(CardObject card)
    {
        this.card = card;

        if (card.IsUseful())
            cardButton.image.sprite = GameManager.GetInstance().usefulSprite;
        else
            cardButton.image.sprite = GameManager.GetInstance().decaySprite;

        nameText.text = card.cardName;
        cardImg.sprite = card.cardTexture;
        cardImg.gameObject.SetActive(true);
    }

    public void Refresh()
    {
        this.card = null;
        cardImg.sprite = null;
        cardImg.gameObject.SetActive(false);
        cardButton.image.sprite = GameManager.GetInstance().nothingSprite;
        nameText.text = string.Empty;
    }

    public void Remove()
    {
        GameManager.GetInstance().ownCards.Remove(card);
        GameManager.GetInstance().Refresh();
    }

    public void OnClick()
    {
        BagUI.GetInstance().SetDescription(this.card);
    }


}
